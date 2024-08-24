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

namespace Svc.App.Common.Auth.Services;

/// <summary>
/// 인증·인가 및 사용자, 권한 서비스 클래스
/// </summary>
public class AuthService
{
    #region Fields
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserRepository _userRepository;
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IUserMenuRoleRepository _userMenuRoleRepository;
    private readonly IMenuRoleRepository _menuRoleRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IEmployeeCompanyRepository _employeeCompanyRepository;
    private readonly EmployeeService _employeeService;
    #endregion
    
    #region Constructor
    public AuthService(
        IConfiguration configuration,
        IHttpContextAccessor httpContextAccessor,
        IUserRepository userRepository,
        IUserRoleRepository userRoleRepository,
        IUserMenuRoleRepository userMenuRoleRepository,
        IMenuRoleRepository menuRoleRepository,
        IRoleRepository roleRepository,
        IEmployeeRepository employeeRepository,
        IEmployeeCompanyRepository employeeCompanyRepository,
        EmployeeService employeeService
    )
    {
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
        _userRepository = userRepository;
        _userRoleRepository = userRoleRepository;
        _userMenuRoleRepository = userMenuRoleRepository;
        _menuRoleRepository = menuRoleRepository;
        _roleRepository = roleRepository;
        _employeeRepository = employeeRepository;
        _employeeCompanyRepository = employeeCompanyRepository;
        _employeeService = employeeService;
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

        var isPasswordMatch = EncryptUtil.Verify(loginRequestDTO.UserPassword!, user.UserPassword!);
        if (!isPasswordMatch)
            throw new BizException("아이디 또는 비밀번호를 확인하세요.");

        SetAuthenticatedUser(user);
        return GenerateJWTToken(user);
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
                user.Employee.EmployeeCompanies = await _employeeCompanyRepository.ListEmployeeCompany(user.Employee.EmployeeId);
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

            // 직원 회사 추가
            if (addUserRequestDTO.Employee.EmployeeCompany != null)
            {
                addUserRequestDTO.Employee.EmployeeCompany.EmployeeId = employeeId;
                addUserRequestDTO.Employee.EmployeeCompany.CreaterId = addUserRequestDTO.CreaterId;
                
                await _employeeService.AddEmployeeCompany(addUserRequestDTO.Employee.EmployeeCompany);
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

            // 직원 회사 수정
            if (updateUserRequestDTO.Employee.EmployeeCompany != null)
            {
                updateUserRequestDTO.Employee.EmployeeCompany.EmployeeId = updateUserRequestDTO.Employee.EmployeeId;
                updateUserRequestDTO.Employee.EmployeeCompany.UpdaterId = updateUserRequestDTO.UpdaterId;
                
                await _employeeService.SaveEmployeeCompany(updateUserRequestDTO.Employee.EmployeeCompany);
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
        var updaterId = int.Parse(user?.FindFirstValue(ClaimUtil.USER_ID_IDENTIFIER)!);
        
        return await _userRepository.RemoveUser(userId, updaterId);
    }

    /// <summary>
    /// 권한 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<RoleResponseDTO>> ListRole()
        => await _roleRepository.ListRole();

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
            new(ClaimUtil.COMPANY_ID_IDENTIFIER, user.Employee!.CompanyId.ToString()!),
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
    public string GenerateJWTToken(LoginResultDTO user)
    {
        var claims = new List<Claim> {
            new(ClaimUtil.USER_ID_IDENTIFIER, user.UserId.ToString()!),
            new(ClaimUtil.USER_ACCOUNT_IDENTIFIER, user.UserAccount!),
            new(ClaimUtil.COMPANY_ID_IDENTIFIER, user.Employee!.CompanyId.ToString()!),
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
