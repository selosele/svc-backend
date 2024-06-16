using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using svc.App.Auth.Models.DTO;
using svc.App.Auth.Models.Entities;
using svc.App.Auth.Repositories;
using svc.App.Shared.Exceptions;
using svc.App.Shared.Utils;

namespace svc.App.Auth.Services;

/// <summary>
/// 인증·인가 서비스 클래스
/// </summary>
public class AuthService
{
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserRepository _userRepository;
    private readonly UserRoleRepository _userRoleRepository;
    public AuthService(
        IConfiguration configuration,
        IHttpContextAccessor httpContextAccessor,
        UserRepository userRepository,
        UserRoleRepository userRoleRepository
    )
    {
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
        _userRepository = userRepository;
        _userRoleRepository = userRoleRepository;
    }

    /// <summary>
    /// 로그인을 한다.
    /// </summary>
    public async Task<string> Login(LoginRequestDTO loginRequestDTO)
    {
        var user = await GetUser(loginRequestDTO)
            ?? throw new BizException("로그인에 실패했습니다.");

        var matchPassword = EncryptUtil.Verify(loginRequestDTO.UserPassword!, user.UserPassword!);
        if (!matchPassword)
        {
            throw new BizException("로그인에 실패했습니다.");
        }

        SetAuthenticatedUser(user);
        return GenerateJWTToken(user);
    }

    /// <summary>
    /// 로그아웃을 한다.
    /// </summary>
    public void Logout()
    {
        _httpContextAccessor.HttpContext!.User = null!;
    }

    /// <summary>
    /// 사용자를 조회한다.
    /// </summary>
    public async Task<UserEntity?> GetUser(GetUserRequestDTO getUserRequestDTO)
    {
        var user = await _userRepository.GetUser(getUserRequestDTO);
        if (user != null)
        {
            var userRoles = await ListUserRole(user);
            user!.Roles = userRoles;
        }
        return user;
    }

    /// <summary>
    /// 사용자 권한 목록을 조회한다.
    /// </summary>
    public async Task<List<UserRoleEntity>> ListUserRole(UserEntity user)
    {
        return await _userRoleRepository.ListUserRole(new GetUserRoleRequestDTO { UserId = user?.UserId });
    }

    /// <summary>
    /// 사용자를 추가한다.
    /// </summary>
    public async Task<UserEntity> AddUser(AddUserRequestDTO addUserRequestDTO)
    {
        // 사용자 중복 체크
        var foundUser = await GetUser(addUserRequestDTO);
        if (foundUser != null) throw new BizException("중복된 사용자입니다. 입력하신 정보를 다시 확인하세요.");

        // 비밀번호 암호화
        addUserRequestDTO.UserPassword = EncryptUtil.Encrypt(addUserRequestDTO.UserPassword!);

        // 사용자 추가
        var addedUser = await _userRepository.AddUser(addUserRequestDTO);

        // 사용자 권한 추가
        foreach (var roleId in addUserRequestDTO.RoleIdList!)
        {
            await _userRoleRepository.AddUserRole(
                new AddUserRoleRequestDTO() { UserId = addedUser?.UserId, RoleId = roleId }
            );
        }

        addedUser!.UserPassword = null;
        addedUser.Roles = await ListUserRole(addedUser);

        return addedUser;
    }

    /// <summary>
    /// 인증된 사용자 정보를 반환한다.
    /// </summary>
    public ClaimsPrincipal? GetAuthenticatedUser()
    {
        return _httpContextAccessor.HttpContext?.User
            ?? throw new InvalidOperationException("인증된 사용자를 찾을 수 없습니다.");
    }

    /// <summary>
    /// 인증된 사용자 정보를 저장한다.
    /// </summary>
    public void SetAuthenticatedUser(UserEntity user)
    {
        var claims = new List<Claim>
        {
            new("userId", user.UserId.ToString()!),
            new("userAccount", user.UserAccount!),
            new("userName", user.UserName!)
        };

        foreach (var userRole in user.Roles!)
        {
            claims.Add(new Claim("roles", userRole.RoleId!));
        }

        var identity = new ClaimsIdentity(claims, "Custom");
        var principal = new ClaimsPrincipal(identity);

        _httpContextAccessor.HttpContext!.User = principal;
    }

    /// <summary>
    /// JWT를 생성해서 반환한다.
    /// </summary>
    public string GenerateJWTToken(UserEntity user) {
        var claims = new List<Claim> {
            new("userId", user.UserId.ToString()!),
            new("userAccount", user.UserAccount!),
            new("userName", user.UserName!)
        };

        foreach (var userRole in user.Roles!)
        {
            claims.Add(new Claim("roles", userRole.RoleId!));
        }

        var accessToken = new JwtSecurityToken(
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddDays(30),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["ApplicationSettings:JWTSecret"]!)),
                    SecurityAlgorithms.HmacSha256Signature
                )
            );
        return new JwtSecurityTokenHandler().WriteToken(accessToken);
    }
    
}
