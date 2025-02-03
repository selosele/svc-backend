using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SmartSql.AOP;
using Svc.App.Shared.Utils;
using Svc.App.Shared.Extensions;
using Svc.App.Shared.Exceptions;
using Svc.App.Common.Auth.Models.DTO;
using Svc.App.Common.User.Models.DTO;
using Svc.App.Common.User.Mappers;
using Svc.App.Common.Mail.Models.DTO;
using Svc.App.Common.Mail.Services;
using Svc.App.Human.Employee.Models.DTO;
using Svc.App.Human.Employee.Mappers;
using Svc.App.Common.Notification.Models.DTO;
using Svc.App.Common.Notification.Mappers;

namespace Svc.App.Common.Auth.Services;

/// <summary>
/// 인증·인가 서비스 클래스
/// </summary>
public class AuthService
{
    #region [필드]
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserMapper _userMapper;
    private readonly UserCertHistoryMapper _userCertHistoryMapper;
    private readonly UserRoleMapper _userRoleMapper;
    private readonly EmployeeMapper _employeeMapper;
    private readonly WorkHistoryMapper _workHistoryMapper;
    private readonly NotificationMapper _notificationMapper;
    private readonly MyMailService _mailService;
    #endregion
    
    #region [생성자]
    public AuthService(
        IConfiguration configuration,
        IHttpContextAccessor httpContextAccessor,
        UserMapper userMapper,
        UserCertHistoryMapper userCertHistoryMapper,
        UserRoleMapper userRoleMapper,
        EmployeeMapper employeeMapper,
        WorkHistoryMapper workHistoryMapper,
        NotificationMapper notificationMapper,
        MyMailService mailService
    )
    {
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
        _userMapper = userMapper;
        _userCertHistoryMapper = userCertHistoryMapper;
        _userRoleMapper = userRoleMapper;
        _employeeMapper = employeeMapper;
        _workHistoryMapper = workHistoryMapper;
        _notificationMapper = notificationMapper;
        _mailService = mailService;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 로그인을 한다.
    /// </summary>
    [Transaction]
    public async Task<string> Login(LoginRequestDTO dto)
    {
        // 사용자가 존재하는지 확인한다.
        var user = await GetUserLogin(dto)
            ?? throw new BizException("아이디 또는 비밀번호를 확인하세요.");

        // 슈퍼로그인이 아닌 경우에만 사용자 검증을 한다.
        if (string.IsNullOrEmpty(dto.IsSuperLogin) || dto.IsSuperLogin == "N")
        {
            // 비활성화된 사용자는 로그인하지 못하도록 한다.
            if (user.UserActiveYn == "N")
                throw new BizException("로그인 잠금 처리된 계정이에요. 시스템관리자에게 문의해주세요.");

            // 비밀번호를 비교한다.
            var isPasswordMatch = EncryptUtil.Verify(dto.UserPassword!, user.UserPassword!);
            if (!isPasswordMatch)
                throw new BizException("아이디 또는 비밀번호를 확인하세요.");

            // 임시 비밀번호를 발급했을경우 임시 비밀번호의 유효시간을 검증한다.
            if (user.TempPasswordYn == "Y")
            {
                var count = await _userMapper.CountUserTempPasswordValid(user.UserId);
                if (count == 0)
                    throw new BizException("아이디 또는 비밀번호를 확인하세요.");

                // 임시 비밀번호 변경 알림을 발송한다.
                await _notificationMapper.AddNotification(new AddNotificationRequestDTO
                {
                    UserId = user.UserId,
                    NotificationTitle = "임시 비밀번호를 변경해주세요.",
                    NotiticationContent = $@"
                        회원님께서는 {DateTime.Parse(user.TempPasswordDt!):yyyy-MM-dd HH:mm:ss} 임시 비밀번호를 발급받으셨어요.
                        임시 비밀번호의 유효시간은 2시간이므로 유효시간 내에 비밀번호를 변경하지 않으시면 다시 발급받으셔야 해요.
                        보안을 위해 반드시 비밀번호를 변경해주세요.
                    ",
                    NotificationTypeCode = "URGENT",
                    NotificationKindCode = "CHANGE_PW",
                    CreaterId = user.UserId
                });
            }

            if (string.IsNullOrEmpty(user.LastLoginDt) && user.Roles!.Where(x => x.RoleId == RoleUtil.SYSTEM_ADMIN).IsNullOrEmpty())
            {
                // 처음 로그인하는 경우 알림을 발송한다(시스템관리자 제외).
                await _notificationMapper.AddNotification(new AddNotificationRequestDTO
                {
                    UserId = user.UserId,
                    NotificationTitle = "안녕하세요 반가워요.",
                    NotiticationContent = "서비스 이용 중 문의사항은 시스템관리자(01055943384)에게 문의해주세요.",
                    NotificationTypeCode = "NORMAL",
                    NotificationKindCode = "FIRST_LOGIN",
                    CreaterId = user.UserId
                });
            }
        }

        // 인증된 사용자 정보를 설정한다.
        SetAuthenticatedUser(user);

        // 슈퍼로그인이 아닌 경우에만 사용자의 마지막 로그인 일시를 변경한다.
        if (string.IsNullOrEmpty(dto.IsSuperLogin) || dto.IsSuperLogin == "N")
        {
            await _userMapper.UpdateUserLastLoginDt(user.UserId, user.UserId);
        }

        // JWT를 생성해서 반환한다.
        return GenerateJWT(user);
    }

    /// <summary>
    /// 로그아웃을 한다.
    /// </summary>
    public void Logout()
        => _httpContextAccessor.HttpContext!.User = null!;

    /// <summary>
    /// 사용자를 조회한다(로그인용).
    /// </summary>
    [Transaction]
    public async Task<LoginResultDTO?> GetUserLogin(LoginRequestDTO dto)
    {
        var user = await _userMapper.GetUserLogin(dto);
        if (user != null)
        {
            user.Roles = await _userRoleMapper.ListUserRole(new GetUserRoleRequestDTO { UserId = user.UserId });
            user.Employee = await _employeeMapper.GetEmployee(new GetEmployeeRequestDTO { UserId = user.UserId });

            if (user.Employee != null)
            {
                user.Employee.WorkHistories = await _workHistoryMapper.ListWorkHistory(new GetWorkHistoryRequestDTO
                {
                    UserId = user.UserId,
                    EmployeeId = user.Employee.EmployeeId
                });
            }
        }
        return user;
    }

    /// <summary>
    /// 사용자의 아이디를 찾는다.
    /// </summary>
    [Transaction]
    public async Task<bool> FindUserAccount(FindUserInfoRequestDTO dto)
    {
        var foundUser = await _userMapper.GetUserFindInfo(dto)
            ?? throw new BizException("가입된 정보가 없어요. 입력하신 정보를 다시 확인하세요.");

        var mailSend = await _mailService.Send(new SendMailDTO
        {
            To = foundUser?.EmailAddr,
            Subject = "아이디 확인 메일",
            Body = $@"
                <p>{foundUser?.EmployeeName}님 안녕하세요.</p><br>
                <p>회원님께서 조회하신 아이디는 아래와 같아요.</p<br>

                <ul>
                    <li>아이디: <strong>{foundUser?.UserAccount}</strong></li>
                    <li>계정 생성일시: {DateTime.Parse(foundUser?.CreateDt!):yyyy-MM-dd HH:mm:ss}</li>
                    <li>마지막 로그인 일시: {DateTime.Parse(foundUser?.LastLoginDt!):yyyy-MM-dd HH:mm:ss}</li>
                </ul>

                <p>아이디 확인 요청을 한 사람이 본인이 아닌 경우, 보안을 위해 시스템관리자(010-5594-3384)에게 연락해주세요.</p><br>
                <p>감사합니다.</p>
            "
        });

        if (!mailSend)
            throw new BizException("메일 발송에 실패했어요.");

        return true;
    }

    /// <summary>
    /// 사용자의 비밀번호를 찾는다(인증코드 발송).
    /// </summary>
    [Transaction]
    public async Task<UserCertHistoryResponseDTO> FindUserPassword1(FindUserInfoRequestDTO dto)
    {
        var foundUser = await _userMapper.GetUserFindInfo(dto)
            ?? throw new BizException("가입된 정보가 없어요. 입력하신 정보를 다시 확인하세요.");

        // 본인인증 코드 생성
        var certCode = RandomStringGeneratorUtil.Generate(6);

        // 사용자 본인인증 이력 추가
        int certHistoryId = await _userCertHistoryMapper.AddUserCertHistory(new AddUserCertHistoryRequestDTO
        {
            UserAccount = foundUser.UserAccount,
            PhoneNo = foundUser.PhoneNo,
            EmailAddr = foundUser.EmailAddr,
            CertCode = certCode,
            CertMethodCode = "EMAIL",
            CertTypeCode = "FIND_PW",
            ValidTime = 180 // 3분
        });

        // 사용자 본인인증 이력 조회
        var userCertHistory = await _userCertHistoryMapper.GetUserCertHistory(new GetUserCertHistoryRequestDTO
        {
            CertHistoryId = certHistoryId
        });

        // 본인인증 코드 유효시간
        TimeSpan validTime = TimeSpan.FromSeconds((double)userCertHistory.ValidTime!);
        string validTimeToMinute = validTime.ToString(@"mm");

        // 본인인증 코드 발송
        var mailSend = await _mailService.Send(new SendMailDTO
        {
            To = foundUser?.EmailAddr,
            Subject = "비밀번호 찾기 본인인증 메일",
            Body = $@"
                <p>{foundUser?.EmployeeName}님 안녕하세요.</p><br>
                <p>비밀번호 찾기를 위한 인증코드는 아래와 같아요.</p><br>

                <ul>
                    <li>인증코드: <strong>{userCertHistory.CertCode}</strong></li>
                    <li>인증코드 발급일시: {DateTime.Parse(userCertHistory.CreateDt!):yyyy-MM-dd HH:mm:ss}</li>
                    <li>인증코드 유효시간: {validTimeToMinute}분</li>
                </ul>

                <p>본인인증 요청을 한 사람이 본인이 아닌 경우, 보안을 위해 시스템관리자(010-5594-3384)에게 연락해주세요.</p><br>
                <p>감사합니다.</p>
            "
        });

        if (!mailSend)
            throw new BizException("메일 발송에 실패했어요.");

        return userCertHistory;
    }

    /// <summary>
    /// 사용자의 비밀번호를 찾는다(임시 비밀번호 발급).
    /// </summary>
    [Transaction]
    public async Task<bool> FindUserPassword2(FindUserInfoRequestDTO dto)
    {
        var foundUser = await _userMapper.GetUserFindInfo(dto)
            ?? throw new BizException("가입된 정보가 없어요. 입력하신 정보를 다시 확인하세요.");

        // 사용자 본인인증 이력 조회
        var userCertHistoryCount = await _userCertHistoryMapper.CountUserCertHistory(new GetUserCertHistoryRequestDTO
        {
            UserAccount = dto.UserAccount,
            EmailAddr = dto.EmailAddr,
            CertCode = dto.CertCode
        });

        if (userCertHistoryCount == 0)
            throw new BizException("인증코드가 틀렸거나 유효시간이 만료되었어요.");

        // 임시 비밀번호 생성
        var length = _configuration["ApplicationSettings:GenerateTempPasswordLength"]!;
        var tempPassword = RandomStringGeneratorUtil.Generate(int.Parse(length));

        // 사용자 비밀번호를 임시 비밀번호로 변경
        await _userMapper.UpdateUserPassword(new UpdateUserPasswordRequestDTO
        {
            TempPasswordYn = "Y",
            NewPassword = EncryptUtil.Encrypt(tempPassword),
            UserAccount = foundUser.UserAccount,
            UpdaterId = foundUser.UserId
        });

        // 임시 비밀번호 발송
        var mailSend = await _mailService.Send(new SendMailDTO
        {
            To = foundUser?.EmailAddr,
            Subject = "임시 비밀번호 발급 메일",
            Body = $@"
                <p>{foundUser?.EmployeeName}님 안녕하세요.</p><br>
                <p>{foundUser?.EmployeeName}님의 임시 비밀번호는 아래와 같아요.</p><br>

                <ul>
                    <li>임시 비밀번호: <strong>{tempPassword}</strong></li>
                    <li>임시 비밀번호 발급일시: {DateTime.Parse(DateTime.Now.ToString()):yyyy-MM-dd HH:mm:ss}</li>
                    <li>임시 비밀번호 유효시간: 2시간</li>
                </ul>

                <p><strong>로그인 후 반드시 비밀번호를 변경해주세요.</strong></p><br>
                <p>임시 비밀번호 발급 요청을 한 사람이 본인이 아닌 경우, 보안을 위해 시스템관리자(010-5594-3384)에게 연락해주세요.</p><br>
                <p>감사합니다.</p>
            "
        });

        if (!mailSend)
            throw new BizException("메일 발송에 실패했어요.");
        
        return true;
    }

    /// <summary>
    /// 로그인 여부를 반환한다.
    /// </summary>
    public bool IsLogined()
        => GetAuthenticatedUser() != null;

    /// <summary>
    /// 1개의 권한을 가지고 있는지 여부를 반환한다.
    /// </summary>
    public bool HasRole(string roleId)
    {
        var user = GetAuthenticatedUser();
        if (user == null)
            return false;
        
        return user.Roles!.Any(x => x.RoleId == roleId);
    }

    /// <summary>
    /// 인증된 사용자 정보를 반환한다.
    /// </summary>
    public UserResponseDTO GetAuthenticatedUser()
    {
        var principal = _httpContextAccessor.HttpContext?.User;
        var isAuthenticated = principal!.Identity!.IsAuthenticated;
        if (!isAuthenticated)
            return null!;

        return principal!.GetUser();
    }

    /// <summary>
    /// 인증된 사용자 정보를 저장한다.
    /// </summary>
    private void SetAuthenticatedUser(LoginResultDTO user)
    {
        var claims = GetClaims(user);
        var identity = new ClaimsIdentity(claims, "Custom");
        var principal = new ClaimsPrincipal(identity);

        _httpContextAccessor.HttpContext!.User = principal;
    }

    /// <summary>
    /// JWT를 생성해서 반환한다.
    /// </summary>
    private string GenerateJWT(LoginResultDTO user)
    {
        var claims = GetClaims(user);
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

    /// <summary>
    /// claim를 설정해서 반환한다.
    /// </summary>
    private static List<Claim> GetClaims(LoginResultDTO user)
    {
        var claims = new List<Claim>
        {
            new(ClaimUtil.USER_ID_IDENTIFIER, user.UserId.ToString()!),
            new(ClaimUtil.USER_ACCOUNT_IDENTIFIER, user.UserAccount!),
            new(ClaimUtil.WORK_HISTORY_ID_IDENTIFIER, user.Employee!.WorkHistories![0].WorkHistoryId.ToString()! ?? ""),
            new(ClaimUtil.COMPANY_NAME_IDENTIFIER, user.Employee!.WorkHistories![0].CompanyName?.ToString()! ?? ""),
            new(ClaimUtil.RANK_CODE_IDENTIFIER, user.Employee!.WorkHistories![0].RankCode?.ToString()! ?? ""),
            new(ClaimUtil.RANK_CODE_NAME_IDENTIFIER, user.Employee!.WorkHistories![0].RankCodeName?.ToString()! ?? ""),
            new(ClaimUtil.JOB_TITLE_CODE_IDENTIFIER, user.Employee!.WorkHistories![0].JobTitleCode?.ToString()! ?? ""),
            new(ClaimUtil.JOB_TITLE_CODE_NAME_IDENTIFIER, user.Employee!.WorkHistories![0].JobTitleCodeName?.ToString()! ?? ""),
            new(ClaimUtil.JOIN_YMD_IDENTIFIER, user.Employee!.WorkHistories![0].JoinYmd?.ToString()! ?? ""),
            new(ClaimUtil.QUIT_YMD_IDENTIFIER, user.Employee!.WorkHistories![0].QuitYmd?.ToString()! ?? ""),
            new(ClaimUtil.EMPLOYEE_ID_IDENTIFIER, user.Employee!.EmployeeId.ToString()! ?? ""),
            new(ClaimUtil.EMPLOYEE_NAME_IDENTIFIER, user.Employee!.EmployeeName! ?? "")
        };

        foreach (var i in user.Roles!)
        {
            claims.Add(new(ClaimUtil.ROLES_IDENTIFIER, i.RoleId!));
        }

        return claims;
    }
    #endregion
    
}
