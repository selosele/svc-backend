using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using svc.App.Auth.Models.DTO;
using svc.App.Auth.Models.Entities;
using svc.App.Auth.Repositories;
using svc.App.Menu.Repositories;
using svc.App.Menu.Models.DTO;
using svc.App.Shared.Exceptions;
using svc.App.Shared.Utils;
using SmartSql.AOP;

namespace svc.App.Auth.Services;

/// <summary>
/// 인증·인가 서비스 클래스
/// </summary>
public class AuthService
{
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserRepository _userRepository;
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IUserMenuRoleRepository _userMenuRoleRepository;
    private readonly IMenuRoleRepository _menuRoleRepository;
    
    public AuthService(
        IConfiguration configuration,
        IHttpContextAccessor httpContextAccessor,
        IUserRepository userRepository,
        IUserRoleRepository userRoleRepository,
        IUserMenuRoleRepository userMenuRoleRepository,
        IMenuRoleRepository menuRoleRepository
    )
    {
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
        _userRepository = userRepository;
        _userRoleRepository = userRoleRepository;
        _userMenuRoleRepository = userMenuRoleRepository;
        _menuRoleRepository = menuRoleRepository;
    }

    /// <summary>
    /// 로그인을 한다.
    /// </summary>
    [Transaction]
    public async Task<string> Login(LoginRequestDTO loginRequestDTO)
    {
        var user = await GetUser(loginRequestDTO)
            ?? throw new BizException("아이디 또는 비밀번호를 확인해주세요.");

        if (user.UserActiveYn == "N")
            throw new BizException("비활성화된 사용자입니다.");

        var matchPassword = EncryptUtil.Verify(loginRequestDTO.UserPassword!, user.UserPassword!);
        if (!matchPassword)
            throw new BizException("아이디 또는 비밀번호를 확인해주세요.");

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
    /// 사용자 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<UserEntity>> ListUser()
    {
        var userList = await _userRepository.ListUser();
        foreach (var user in userList)
        {
            var userRoleList = await _userRoleRepository.ListUserRole(new GetUserRoleRequestDTO{ UserId = user.UserId });
            user.Roles = userRoleList;
        }
        return userList;
    }

    /// <summary>
    /// 사용자를 조회한다.
    /// </summary>
    [Transaction]
    public async Task<UserEntity?> GetUser(GetUserRequestDTO getUserRequestDTO)
    {
        var user = await _userRepository.GetUser(getUserRequestDTO);
        if (user != null)
        {
            var userRoles = await ListUserRole(user);
            user.Roles = userRoles;
        }
        return user;
    }

    /// <summary>
    /// 사용자 권한 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<UserRoleEntity>> ListUserRole(UserEntity user)
    {
        return await _userRoleRepository.ListUserRole(new GetUserRoleRequestDTO { UserId = user?.UserId });
    }

    /// <summary>
    /// 사용자를 추가한다.
    /// </summary>
    [Transaction]
    public async Task<UserEntity?> AddUser(AddUserRequestDTO addUserRequestDTO)
    {
        // 사용자 중복 체크
        var foundUser = await GetUser(addUserRequestDTO);
        if (foundUser != null) throw new BizException("중복된 사용자입니다. 입력하신 정보를 다시 확인하세요.");

        // 비밀번호 암호화
        addUserRequestDTO.UserPassword = EncryptUtil.Encrypt(addUserRequestDTO.UserPassword!);

        // 사용자 추가
        var userId = await _userRepository.AddUser(addUserRequestDTO);

        // 사용자 권한 추가
        foreach (var roleId in addUserRequestDTO.RoleIdList!)
        {
            await _userRoleRepository.AddUserRole(
                new AddUserRoleRequestDTO()
                {
                    UserId = userId,
                    RoleId = roleId
                }
            );
        }

        // 메뉴 권한 목록 조회
        var menuRoleList = await _menuRoleRepository.ListMenuRole(new GetMenuRoleRequestDTO()
        {
            UserId = userId
        });

        // 사용자 메뉴 권한 추가
        foreach (var menuRole in menuRoleList)
        {
            await _userMenuRoleRepository.AddUserMenuRole(
                new AddUserMenuRoleRequestDTO()
                {
                    UserId = userId,
                    MenuId = menuRole.MenuId,
                    RoleId = menuRole.RoleId
                }
            );
        }

        var addedUser = await GetUser(new GetUserRequestDTO { UserId = userId });
        if (addedUser != null)
        {
            addedUser.UserPassword = null;
            addedUser.Roles = await ListUserRole(addedUser);
        }

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
            new(ClaimUtil.IdIdentifier, user.UserId.ToString()!),
            new(ClaimUtil.AccountIdentifier, user.UserAccount!),
            new(ClaimUtil.NameIdentifier, user.UserName!)
        };

        foreach (var userRole in user.Roles!)
        {
            claims.Add(new Claim(ClaimUtil.RolesIdentifier, userRole.RoleId!));
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
            new(ClaimUtil.IdIdentifier, user.UserId.ToString()!),
            new(ClaimUtil.AccountIdentifier, user.UserAccount!),
            new(ClaimUtil.NameIdentifier, user.UserName!)
        };

        foreach (var userRole in user.Roles!)
        {
            claims.Add(new Claim(ClaimUtil.RolesIdentifier, userRole.RoleId!));
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
