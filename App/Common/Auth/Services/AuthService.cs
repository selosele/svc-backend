using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SmartSql.AOP;
using Svc.App.Common.Auth.Models.DTO;
using Svc.App.Common.Auth.Repositories;
using Svc.App.Common.Menu.Repositories;
using Svc.App.Common.Menu.Models.DTO;
using Svc.App.Shared.Exceptions;
using Svc.App.Shared.Utils;
using Svc.App.Human.Employee.Repositories;
using Svc.App.Human.Employee.Models.DTO;
using Svc.App.Human.Employee.Services;
using Svc.App.Common.Mail.Models.DTO;
using Svc.App.Common.Mail.Services;

namespace Svc.App.Common.Auth.Services;

/// <summary>
/// 인증·인가 및 사용자 서비스 클래스
/// </summary>
public class AuthService
{
    #region Fields
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserRepository _userRepository;
    private readonly IUserCertHistoryRepository _userCertHistoryRepository;
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IUserMenuRoleRepository _userMenuRoleRepository;
    private readonly IMenuRoleRepository _menuRoleRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IWorkHistoryRepository _workHistoryRepository;
    private readonly EmployeeService _employeeService;
    private readonly MyMailService _mailService;
    #endregion
    
    #region Constructor
    public AuthService(
        IConfiguration configuration,
        IHttpContextAccessor httpContextAccessor,
        IUserRepository userRepository,
        IUserCertHistoryRepository userCertHistoryRepository,
        IUserRoleRepository userRoleRepository,
        IUserMenuRoleRepository userMenuRoleRepository,
        IMenuRoleRepository menuRoleRepository,
        IEmployeeRepository employeeRepository,
        IWorkHistoryRepository workHistoryRepository,
        EmployeeService employeeService,
        MyMailService mailService
    )
    {
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
        _userRepository = userRepository;
        _userCertHistoryRepository = userCertHistoryRepository;
        _userRoleRepository = userRoleRepository;
        _userMenuRoleRepository = userMenuRoleRepository;
        _menuRoleRepository = menuRoleRepository;
        _employeeRepository = employeeRepository;
        _workHistoryRepository = workHistoryRepository;
        _employeeService = employeeService;
        _mailService = mailService;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 로그인을 한다.
    /// </summary>
    [Transaction]
    public async Task<string> Login(LoginRequestDTO loginRequestDTO)
    {
        var user = await GetUserLogin(loginRequestDTO)
            ?? throw new BizException("아이디 또는 비밀번호를 확인하세요.");

        if (user.UserActiveYn == "N")
            throw new BizException("비활성화된 사용자입니다.");

        // 비밀번호를 비교한다.
        var isPasswordMatch = EncryptUtil.Verify(loginRequestDTO.UserPassword!, user.UserPassword!);
        if (!isPasswordMatch)
            throw new BizException("아이디 또는 비밀번호를 확인하세요.");

        // 인증된 사용자 정보를 설정한다.
        SetAuthenticatedUser(user);

        var myUser = GetAuthenticatedUser();
        var myUserId = int.Parse(myUser?.FindFirstValue(ClaimUtil.USER_ID_IDENTIFIER)!);

        // 사용자의 마지막 로그인 일시를 변경한다.
        await _userRepository.UpdateUserLastLoginDt(user.UserId, myUserId);

        // JWT를 생성해서 반환한다.
        return GenerateJWT(user);
    }

    /// <summary>
    /// 로그아웃을 한다.
    /// </summary>
    public void Logout()
        => _httpContextAccessor.HttpContext!.User = null!;

    /// <summary>
    /// 사용자 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<UserResponseDTO>> ListUser(GetUserRequestDTO? getUserRequestDTO)
        => await _userRepository.ListUser(getUserRequestDTO);

    /// <summary>
    /// 사용자를 조회한다.
    /// </summary>
    [Transaction]
    public async Task<UserResponseDTO?> GetUser(GetUserRequestDTO getUserRequestDTO)
    {
        var user = await _userRepository.GetUser(getUserRequestDTO);
        if (user != null)
        {
            user.Roles = await _userRoleRepository.ListUserRole(new GetUserRoleRequestDTO { UserId = user.UserId });
            user.Employee = await _employeeRepository.GetEmployee(new GetEmployeeRequestDTO { UserId = user.UserId });

            if (user.Employee != null)
            {
                user.Employee.WorkHistories = await _workHistoryRepository.ListWorkHistory(new GetWorkHistoryRequestDTO { EmployeeId = user.Employee.EmployeeId });
            }
        }
        return user;
    }

    /// <summary>
    /// 사용자를 조회한다(로그인용).
    /// </summary>
    [Transaction]
    public async Task<LoginResultDTO?> GetUserLogin(LoginRequestDTO loginRequestDTO)
    {
        var user = await _userRepository.GetUserLogin(loginRequestDTO);
        if (user != null)
        {
            user.Roles = await _userRoleRepository.ListUserRole(new GetUserRoleRequestDTO { UserId = user.UserId });
            user.Employee = await _employeeRepository.GetEmployee(new GetEmployeeRequestDTO { UserId = user.UserId });

            if (user.Employee != null)
            {
                user.Employee.WorkHistories = await _workHistoryRepository.ListWorkHistory(new GetWorkHistoryRequestDTO { EmployeeId = user.Employee.EmployeeId });
            }
        }
        return user;
    }

    /// <summary>
    /// 사용자를 추가한다.
    /// </summary>
    [Transaction]
    public async Task<UserResponseDTO?> AddUser(AddUserRequestDTO addUserRequestDTO)
    {
        // 사용자 중복 체크
        var foundUser = await GetUser(new GetUserRequestDTO { UserAccount = addUserRequestDTO.UserAccount });
        if (foundUser != null)
            throw new BizException("중복된 사용자입니다. 입력하신 정보를 다시 확인하세요.");

        // 직원 이메일주소 중복 체크
        var foundEmailCount = await _employeeRepository.CountEmployeeEmailAddr(addUserRequestDTO.Employee!.EmailAddr!, null);
        if (foundEmailCount > 0)
            throw new BizException("중복된 이메일주소입니다. 입력하신 정보를 다시 확인하세요.");

        // 비밀번호 암호화
        addUserRequestDTO.UserPassword = EncryptUtil.Encrypt(addUserRequestDTO.UserPassword!);

        // 등록자 ID
        addUserRequestDTO.CreaterId = int.Parse(GetAuthenticatedUser()?.FindFirstValue(ClaimUtil.USER_ID_IDENTIFIER)!);

        // 사용자 추가
        var userId = await _userRepository.AddUser(addUserRequestDTO);

        // 사용자 권한 추가
        List<AddUserRoleRequestDTO> addUserRoleRequestDTOList = [];
        foreach (var roleId in addUserRequestDTO.Roles!)
        {
            addUserRoleRequestDTOList.Add(new AddUserRoleRequestDTO
                {
                    UserId = userId,
                    RoleId = roleId,
                    CreaterId = addUserRequestDTO.CreaterId
                }
            );
        }
        await _userRoleRepository.AddUserRole(addUserRoleRequestDTOList);

        // 메뉴 권한 목록 조회
        var menuRoleList = await _menuRoleRepository.ListMenuRole(new GetMenuRoleRequestDTO { UserId = userId });

        // 사용자 메뉴 권한 추가
        List<AddUserMenuRoleRequestDTO> addUserMenuRoleRequestDTOList = [];
        foreach (var menuRole in menuRoleList)
        {
            addUserMenuRoleRequestDTOList.Add(new AddUserMenuRoleRequestDTO
                {
                    UserId = userId,
                    MenuId = menuRole.MenuId,
                    RoleId = menuRole.RoleId,
                    CreaterId = addUserRequestDTO.CreaterId
                }
            );
        }
        await _userMenuRoleRepository.AddUserMenuRole(addUserMenuRoleRequestDTOList);

        // 직원 추가
        if (addUserRequestDTO.Employee != null)
        {
            addUserRequestDTO.Employee.UserId = userId;
            addUserRequestDTO.Employee.CreaterId = addUserRequestDTO.CreaterId;
            var employeeId = await _employeeRepository.AddEmployee(addUserRequestDTO.Employee);

            // 근무이력 추가
            if (addUserRequestDTO.Employee.WorkHistory != null)
            {
                addUserRequestDTO.Employee.WorkHistory.EmployeeId = employeeId;
                addUserRequestDTO.Employee.WorkHistory.CreaterId = addUserRequestDTO.CreaterId;
                
                await _employeeService.AddWorkHistory(addUserRequestDTO.Employee.WorkHistory);
            }
        }

        // 추가한 사용자를 조회해서 반환
        var addedUser = await GetUser(new GetUserRequestDTO { UserId = userId });
        if (addedUser != null)
        {
            addedUser.Roles = await _userRoleRepository.ListUserRole(new GetUserRoleRequestDTO { UserId = userId });
        }
        return addedUser;
    }

    /// <summary>
    /// 사용자를 수정한다.
    /// </summary>
    [Transaction]
    public async Task<UserResponseDTO?> UpdateUser(UpdateUserRequestDTO updateUserRequestDTO)
    {
        // 직원 이메일주소 중복 체크
        var foundEmailCount = await _employeeRepository.CountEmployeeEmailAddr(updateUserRequestDTO.Employee!.EmailAddr!, updateUserRequestDTO.Employee.EmployeeId);
        if (foundEmailCount > 0)
            throw new BizException("중복된 이메일주소입니다. 입력하신 정보를 다시 확인하세요.");

        var user = GetAuthenticatedUser();
        updateUserRequestDTO.UpdaterId = int.Parse(user?.FindFirstValue(ClaimUtil.USER_ID_IDENTIFIER)!);
        
        // 사용자 수정
        await _userRepository.UpdateUser(updateUserRequestDTO);

        // 사용자 권한 삭제
        await _userRoleRepository.RemoveUserRole(updateUserRequestDTO.UserId);

        // 사용자 권한 추가
        List<AddUserRoleRequestDTO> addUserRoleRequestDTOList = [];
        foreach (var roleId in updateUserRequestDTO.Roles!)
        {
            addUserRoleRequestDTOList.Add(new AddUserRoleRequestDTO
                {
                    UserId = updateUserRequestDTO.UserId,
                    RoleId = roleId,
                    UpdaterId = updateUserRequestDTO.UpdaterId
                }
            );
        }
        await _userRoleRepository.AddUserRole(addUserRoleRequestDTOList);

        // 사용자 메뉴 권한 삭제
        await _userMenuRoleRepository.RemoveUserMenuRole(updateUserRequestDTO.UserId);

        // 메뉴 권한 목록 조회
        var menuRoleList = await _menuRoleRepository.ListMenuRole(new GetMenuRoleRequestDTO { UserId = updateUserRequestDTO.UserId });

        // 사용자 메뉴 권한 추가
        List<AddUserMenuRoleRequestDTO> addUserMenuRoleRequestDTOList = [];
        foreach (var menuRole in menuRoleList)
        {
            addUserMenuRoleRequestDTOList.Add(new AddUserMenuRoleRequestDTO
                {
                    UserId = updateUserRequestDTO.UserId,
                    MenuId = menuRole.MenuId,
                    RoleId = menuRole.RoleId,
                    UpdaterId = updateUserRequestDTO.UpdaterId
                }
            );
        }
        await _userMenuRoleRepository.AddUserMenuRole(addUserMenuRoleRequestDTOList);

        // 직원 수정
        if (updateUserRequestDTO.Employee != null)
        {
            updateUserRequestDTO.Employee.UpdaterId = updateUserRequestDTO.UpdaterId;
            
            await _employeeRepository.UpdateEmployee(updateUserRequestDTO.Employee);

            // 근무이력 수정
            if (updateUserRequestDTO.Employee.WorkHistory != null)
            {
                updateUserRequestDTO.Employee.WorkHistory.EmployeeId = updateUserRequestDTO.Employee.EmployeeId;
                updateUserRequestDTO.Employee.WorkHistory.UpdaterId = updateUserRequestDTO.UpdaterId;
                
                await _employeeService.SaveWorkHistory(updateUserRequestDTO.Employee.WorkHistory);
            }
        }

        // 수정한 사용자를 조회해서 반환
        return await GetUser(new GetUserRequestDTO { UserId = updateUserRequestDTO.UserId });
    }

    /// <summary>
    /// 사용자 비밀번호를 변경한다.
    /// </summary>
    [Transaction]
    public async Task<int> UpdateUserPassword(UpdateUserPasswordRequestDTO updateUserPasswordRequestDTO)
    {
        // DB의 현재 비밀번호를 조회해서
        var currentHashedPassword = await _userRepository.GetUserPassword(updateUserPasswordRequestDTO.UserId);

        // 입력받은 현재 비밀번호와 동일한지 확인하고
        if (!EncryptUtil.Verify(updateUserPasswordRequestDTO.CurrentPassword!, currentHashedPassword!))
            throw new BizException("현재 비밀번호를 확인하세요.");

        // 새 비밀번호와 확인용 새 비밀번호가 동일한지 확인하고
        if (updateUserPasswordRequestDTO.NewPassword != updateUserPasswordRequestDTO.NewPasswordConfirm)
            throw new BizException("새 비밀번호를 확인하세요.");

        // 새 비밀번호를 암호화한다.
        updateUserPasswordRequestDTO.NewPassword = EncryptUtil.Encrypt(updateUserPasswordRequestDTO.NewPassword!);

        return await _userRepository.UpdateUserPassword(updateUserPasswordRequestDTO);
    }

    /// <summary>
    /// 사용자를 삭제한다.
    /// </summary>
    [Transaction]
    public async Task<int> RemoveUser(int userId)
    {
        var user = GetAuthenticatedUser();
        var myUserId = int.Parse(user?.FindFirstValue(ClaimUtil.USER_ID_IDENTIFIER)!);
        
        return await _userRepository.RemoveUser(userId, myUserId);
    }

    /// <summary>
    /// 사용자의 아이디를 찾는다.
    /// </summary>
    [Transaction]
    public async Task<bool> FindUserAccount(FindUserInfoRequestDTO dto)
    {
        var foundUser = await _userRepository.GetUserFindInfo(dto)
            ?? throw new BizException("가입된 정보가 없습니다. 입력하신 정보를 다시 확인하세요.");

        var mailSend = await _mailService.Send(new SendMailDTO
        {
            To = foundUser?.EmailAddr,
            Subject = "아이디 확인 메일",
            Body = $@"
                <p>{foundUser?.EmployeeName}님 안녕하세요.</p><br>
                <p>회원님께서 조회하신 아이디는 다음과 같습니다.</p<br>

                <ul>
                    <li>아이디: {foundUser?.UserAccount}</li>
                    <li>계정 생성일시: {DateTime.Parse(foundUser?.CreateDt!):yyyy-MM-dd HH:mm:ss}</li>
                    <li>마지막 로그인 일시: {DateTime.Parse(foundUser?.LastLoginDt!):yyyy-MM-dd HH:mm:ss}</li>
                </ul>

                <p>아이디 확인 요청을 한 사람이 본인이 아닌 경우, 보안을 위해 시스템관리자(010-5594-3384)에게 연락해주시기 바랍니다.</p><br>
                <p>감사합니다.</p><br>
            "
        });

        if (!mailSend)
            throw new BizException("메일 발송에 실패했습니다.");

        return mailSend;
    }

    /// <summary>
    /// 사용자의 비밀번호를 찾는다.
    /// </summary>
    [Transaction]
    public async Task<UserCertHistoryResponseDTO> FindUserPassword(FindUserInfoRequestDTO dto)
    {
        var foundUser = await _userRepository.GetUserFindInfo(dto)
            ?? throw new BizException("가입된 정보가 없습니다. 입력하신 정보를 다시 확인하세요.");

        // 본인인증 코드 생성
        var certCode = RandomStringGeneratorUtil.Generate(6);

        // 사용자 본인인증 내역 추가
        int certHistoryId = await _userCertHistoryRepository.AddUserCertHistory(new AddUserCertHistoryRequestDTO
        {
            UserAccount = foundUser.UserAccount,
            PhoneNo = foundUser.PhoneNo,
            EmailAddr = foundUser.EmailAddr,
            CertCode = certCode,
            CertMethodCode = "01",
            CertTypeCode = "02",
            ValidTime = 180 // 3분
        });

        // 사용자 본인인증 내역 조회
        var userCertHistory = await _userCertHistoryRepository.GetUserCertHistory(new GetUserCertHistoryRequestDTO
        {
            CertHistoryId = certHistoryId
        });

        // 본인인증 코드 유효시간
        TimeSpan validTime = TimeSpan.FromSeconds((double)userCertHistory.ValidTime!);
        string validTimeToMinute = validTime.ToString(@"mm");

        var mailSend = await _mailService.Send(new SendMailDTO
        {
            To = foundUser?.EmailAddr,
            Subject = "비밀번호 찾기 본인인증 메일",
            Body = $@"
                <p>{foundUser?.EmployeeName}님 안녕하세요.</p><br>
                <p>비밀번호 찾기를 위한 인증코드는 다음과 같습니다.</p<br>

                <ul>
                    <li>인증코드: <strong>{userCertHistory.CertCode}</strong></li>
                    <li>인증코드 발급일시: {DateTime.Parse(userCertHistory.CreateDt!):yyyy-MM-dd HH:mm:ss}</li>
                    <li>인증코드 유효시간: {validTimeToMinute}분</li>
                </ul>

                <p>본인인증 요청을 한 사람이 본인이 아닌 경우, 보안을 위해 시스템관리자(010-5594-3384)에게 연락해주시기 바랍니다.</p><br>
                <p>감사합니다.</p><br>
            "
        });

        if (!mailSend)
            throw new BizException("메일 발송에 실패했습니다.");

        return userCertHistory;
    }

    /// <summary>
    /// 사용자 본인인증 내역이 존재하는지 확인한다.
    /// </summary>
    [Transaction]
    public async Task<int> CountUserCertHistory(GetUserCertHistoryRequestDTO dto)
        => await _userCertHistoryRepository.CountUserCertHistory(dto);

    /// <summary>
    /// 인증된 사용자 정보를 반환한다.
    /// </summary>
    public ClaimsPrincipal? GetAuthenticatedUser()
        => _httpContextAccessor.HttpContext?.User
            ?? throw new InvalidOperationException("인증된 사용자를 찾을 수 없습니다.");

    /// <summary>
    /// 인증된 사용자 정보를 저장한다.
    /// </summary>
    public void SetAuthenticatedUser(LoginResultDTO user)
    {
        var claims = new List<Claim>
        {
            new(ClaimUtil.USER_ID_IDENTIFIER, user.UserId.ToString()!),
            new(ClaimUtil.USER_ACCOUNT_IDENTIFIER, user.UserAccount!),
            new(ClaimUtil.WORK_HISTORY_ID_IDENTIFIER, user.Employee!.WorkHistories![0].WorkHistoryId.ToString()!),
            new(ClaimUtil.COMPANY_NAME_IDENTIFIER, user.Employee!.WorkHistories![0].CompanyName?.ToString()!),
            new(ClaimUtil.RANK_CODE_IDENTIFIER, user.Employee!.WorkHistories![0].RankCode?.ToString()!),
            new(ClaimUtil.RANK_CODE_NAME_IDENTIFIER, user.Employee!.WorkHistories![0].RankCodeName?.ToString()!),
            new(ClaimUtil.JOB_TITLE_CODE_IDENTIFIER, user.Employee!.WorkHistories![0].JobTitleCode?.ToString()!),
            new(ClaimUtil.JOB_TITLE_CODE_NAME_IDENTIFIER, user.Employee!.WorkHistories![0].JobTitleCodeName?.ToString()!),
            new(ClaimUtil.EMPLOYEE_ID_IDENTIFIER, user.Employee!.EmployeeId.ToString()!),
            new(ClaimUtil.EMPLOYEE_NAME_IDENTIFIER, user.Employee!.EmployeeName!)
        };

        foreach (var userRole in user.Roles!)
        {
            claims.Add(new Claim(ClaimUtil.ROLES_IDENTIFIER, userRole.RoleId!));
        }

        var identity = new ClaimsIdentity(claims, "Custom");
        var principal = new ClaimsPrincipal(identity);

        _httpContextAccessor.HttpContext!.User = principal;
    }

    /// <summary>
    /// JWT를 생성해서 반환한다.
    /// </summary>
    public string GenerateJWT(LoginResultDTO user)
    {
        var claims = new List<Claim> {
            new(ClaimUtil.USER_ID_IDENTIFIER, user.UserId.ToString()!),
            new(ClaimUtil.USER_ACCOUNT_IDENTIFIER, user.UserAccount!),
            new(ClaimUtil.WORK_HISTORY_ID_IDENTIFIER, user.Employee!.WorkHistories![0].WorkHistoryId.ToString()!),
            new(ClaimUtil.COMPANY_NAME_IDENTIFIER, user.Employee!.WorkHistories![0].CompanyName?.ToString()!),
            new(ClaimUtil.RANK_CODE_IDENTIFIER, user.Employee!.WorkHistories![0].RankCode?.ToString()!),
            new(ClaimUtil.RANK_CODE_NAME_IDENTIFIER, user.Employee!.WorkHistories![0].RankCodeName?.ToString()!),
            new(ClaimUtil.JOB_TITLE_CODE_IDENTIFIER, user.Employee!.WorkHistories![0].JobTitleCode?.ToString()!),
            new(ClaimUtil.JOB_TITLE_CODE_NAME_IDENTIFIER, user.Employee!.WorkHistories![0].JobTitleCodeName?.ToString()!),
            new(ClaimUtil.EMPLOYEE_ID_IDENTIFIER, user.Employee!.EmployeeId.ToString()!),
            new(ClaimUtil.EMPLOYEE_NAME_IDENTIFIER, user.Employee!.EmployeeName!)
        };

        foreach (var userRole in user.Roles!)
        {
            claims.Add(new Claim(ClaimUtil.ROLES_IDENTIFIER, userRole.RoleId!));
        }

        var accessToken = new JwtSecurityToken(
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddDays(7),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["ApplicationSettings:JWTSecret"]!)
                ),
                SecurityAlgorithms.HmacSha256Signature
            )
        );
        return new JwtSecurityTokenHandler().WriteToken(accessToken);
    }
    #endregion
    
}
