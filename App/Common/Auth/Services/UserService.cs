using System.Security.Claims;
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
using Svc.App.Common.Notification.Repositories;
using Svc.App.Common.Notification.Models.DTO;

namespace Svc.App.Common.Auth.Services;

/// <summary>
/// 사용자 서비스 클래스
/// </summary>
public class UserService
{
    #region Fields
    private readonly IUserRepository _userRepository;
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IUserMenuRoleRepository _userMenuRoleRepository;
    private readonly IMenuRoleRepository _menuRoleRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IWorkHistoryRepository _workHistoryRepository;
    private readonly INotificationRepository _notificationRepository;
    private readonly EmployeeService _employeeService;
    private readonly AuthService _authService;
    #endregion
    
    #region Constructor
    public UserService(
        IUserRepository userRepository,
        IUserRoleRepository userRoleRepository,
        IUserMenuRoleRepository userMenuRoleRepository,
        IMenuRoleRepository menuRoleRepository,
        IEmployeeRepository employeeRepository,
        IWorkHistoryRepository workHistoryRepository,
        INotificationRepository notificationRepository,
        EmployeeService employeeService,
        AuthService authService
    )
    {
        _userRepository = userRepository;
        _userRoleRepository = userRoleRepository;
        _userMenuRoleRepository = userMenuRoleRepository;
        _menuRoleRepository = menuRoleRepository;
        _employeeRepository = employeeRepository;
        _workHistoryRepository = workHistoryRepository;
        _notificationRepository = notificationRepository;
        _employeeService = employeeService;
        _authService = authService;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 사용자 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<UserResponseDTO>> ListUser(GetUserRequestDTO? dto)
        => await _userRepository.ListUser(dto);

    /// <summary>
    /// 사용자를 조회한다.
    /// </summary>
    [Transaction]
    public async Task<UserResponseDTO?> GetUser(GetUserRequestDTO dto)
    {
        var user = await _userRepository.GetUser(dto);
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
    public async Task<UserResponseDTO?> AddUser(AddUserRequestDTO dto)
    {
        // 사용자 중복 체크
        var foundUser = await GetUser(new GetUserRequestDTO { UserAccount = dto.UserAccount });
        if (foundUser != null)
            throw new BizException("중복된 사용자입니다. 입력하신 정보를 다시 확인하세요.");

        // 직원 이메일주소 중복 체크
        var foundEmailCount = await _employeeRepository.CountEmployeeEmailAddr(dto.Employee!.EmailAddr!, null);
        if (foundEmailCount > 0)
            throw new BizException("중복된 이메일주소입니다. 입력하신 정보를 다시 확인하세요.");

        // 비밀번호 암호화
        dto.UserPassword = EncryptUtil.Encrypt(dto.UserPassword!);

        // 등록자 ID
        dto.CreaterId = int.Parse(_authService.GetAuthenticatedUser()?.FindFirstValue(ClaimUtil.USER_ID_IDENTIFIER)!);

        // 사용자 추가
        var userId = await _userRepository.AddUser(dto);

        // 사용자 권한 추가
        List<AddUserRoleRequestDTO> addUserRoleRequestDTOList = [];
        foreach (var roleId in dto.Roles!)
        {
            addUserRoleRequestDTOList.Add(new AddUserRoleRequestDTO
            {
                UserId = userId,
                RoleId = roleId,
                CreaterId = dto.CreaterId
            });
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
                CreaterId = dto.CreaterId
            });
        }
        await _userMenuRoleRepository.AddUserMenuRole(addUserMenuRoleRequestDTOList);

        // 직원 추가
        if (dto.Employee != null)
        {
            dto.Employee.UserId = userId;
            dto.Employee.CreaterId = dto.CreaterId;
            var employeeId = await _employeeRepository.AddEmployee(dto.Employee);

            // 근무이력 추가
            if (dto.Employee.WorkHistory != null)
            {
                dto.Employee.WorkHistory.EmployeeId = employeeId;
                dto.Employee.WorkHistory.CreaterId = dto.CreaterId;
                
                await _employeeService.AddWorkHistory(dto.Employee.WorkHistory);
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
    public async Task<UserResponseDTO?> UpdateUser(UpdateUserRequestDTO dto)
    {
        // 직원 이메일주소 중복 체크
        var foundEmailCount = await _employeeRepository.CountEmployeeEmailAddr(dto.Employee!.EmailAddr!, dto.Employee.EmployeeId);
        if (foundEmailCount > 0)
            throw new BizException("중복된 이메일주소입니다. 입력하신 정보를 다시 확인하세요.");

        var user = _authService.GetAuthenticatedUser();
        dto.UpdaterId = int.Parse(user?.FindFirstValue(ClaimUtil.USER_ID_IDENTIFIER)!);
        
        // 사용자 수정
        await _userRepository.UpdateUser(dto);

        // 사용자 권한 삭제
        await _userRoleRepository.RemoveUserRole(dto.UserId);

        // 사용자 권한 추가
        List<AddUserRoleRequestDTO> addUserRoleRequestDTOList = [];
        foreach (var roleId in dto.Roles!)
        {
            addUserRoleRequestDTOList.Add(new AddUserRoleRequestDTO
            {
                UserId = dto.UserId,
                RoleId = roleId,
                UpdaterId = dto.UpdaterId
            });
        }
        await _userRoleRepository.AddUserRole(addUserRoleRequestDTOList);

        // 사용자 메뉴 권한 삭제
        await _userMenuRoleRepository.RemoveUserMenuRole(dto.UserId);

        // 메뉴 권한 목록 조회
        var menuRoleList = await _menuRoleRepository.ListMenuRole(new GetMenuRoleRequestDTO { UserId = dto.UserId });

        // 사용자 메뉴 권한 추가
        List<AddUserMenuRoleRequestDTO> addUserMenuRoleRequestDTOList = [];
        foreach (var menuRole in menuRoleList)
        {
            addUserMenuRoleRequestDTOList.Add(new AddUserMenuRoleRequestDTO
            {
                UserId = dto.UserId,
                MenuId = menuRole.MenuId,
                RoleId = menuRole.RoleId,
                UpdaterId = dto.UpdaterId
            });
        }
        await _userMenuRoleRepository.AddUserMenuRole(addUserMenuRoleRequestDTOList);

        // 직원 수정
        if (dto.Employee != null)
        {
            dto.Employee.UpdaterId = dto.UpdaterId;
            
            await _employeeRepository.UpdateEmployee(dto.Employee);

            // 근무이력 수정
            if (dto.Employee.WorkHistory != null)
            {
                dto.Employee.WorkHistory.EmployeeId = dto.Employee.EmployeeId;
                dto.Employee.WorkHistory.UpdaterId = dto.UpdaterId;
                
                await _employeeService.SaveWorkHistory(dto.Employee.WorkHistory);
            }
        }

        // 수정한 사용자를 조회해서 반환
        return await GetUser(new GetUserRequestDTO { UserId = dto.UserId });
    }

    /// <summary>
    /// 사용자 비밀번호를 변경한다.
    /// </summary>
    [Transaction]
    public async Task<int> UpdateUserPassword(UpdateUserPasswordRequestDTO dto)
    {
        // DB의 현재 비밀번호를 조회해서
        var currentHashedPassword = await _userRepository.GetUserPassword(dto.UserId);

        // 입력받은 현재 비밀번호와 동일한지 확인하고
        if (!EncryptUtil.Verify(dto.CurrentPassword!, currentHashedPassword!))
            throw new BizException("현재 비밀번호를 확인하세요.");

        // 새 비밀번호와 확인용 새 비밀번호가 동일한지 확인하고
        if (dto.NewPassword != dto.NewPasswordConfirm)
            throw new BizException("새 비밀번호를 확인하세요.");

        // 새 비밀번호를 암호화한다.
        dto.NewPassword = EncryptUtil.Encrypt(dto.NewPassword!);

        var updateCount = await _userRepository.UpdateUserPassword(dto);
        if (updateCount > 0)
        {
            // 임시 비밀번호 변경 알림을 삭제한다.
            await _notificationRepository.RemoveNotification(new SaveNotificationRequestDTO
            {
                UpdaterId = dto.UserId,
                UserId = dto.UserId,
                NotificationKindCode = "02",
            });
        }
        return updateCount;
    }

    /// <summary>
    /// 사용자를 삭제한다.
    /// </summary>
    [Transaction]
    public async Task<int> RemoveUser(int userId)
    {
        var user = _authService.GetAuthenticatedUser();
        var myUserId = int.Parse(user?.FindFirstValue(ClaimUtil.USER_ID_IDENTIFIER)!);
        
        return await _userRepository.RemoveUser(userId, myUserId);
    }
    #endregion
    
}
