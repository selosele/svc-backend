using SmartSql.AOP;
using Svc.App.Common.User.Models.DTO;
using Svc.App.Common.User.Mappers;
using Svc.App.Common.Menu.Mappers;
using Svc.App.Common.Menu.Models.DTO;
using Svc.App.Shared.Exceptions;
using Svc.App.Shared.Utils;
using Svc.App.Common.Auth.Services;
using Svc.App.Human.Employee.Mappers;
using Svc.App.Human.Employee.Models.DTO;
using Svc.App.Human.Employee.Services;
using Svc.App.Common.Notification.Mappers;
using Svc.App.Common.Notification.Models.DTO;

namespace Svc.App.Common.User.Services;

/// <summary>
/// 사용자 서비스 클래스
/// </summary>
public class UserService
{
    #region [필드]
    private readonly UserMapper _userMapper;
    private readonly UserSetupMapper _userSetupMapper;
    private readonly UserRoleMapper _userRoleMapper;
    private readonly UserMenuRoleMapper _userMenuRoleMapper;
    private readonly MenuRoleMapper _menuRoleMapper;
    private readonly EmployeeMapper _employeeMapper;
    private readonly WorkHistoryMapper _workHistoryMapper;
    private readonly NotificationMapper _notificationMapper;
    private readonly EmployeeService _employeeService;
    private readonly AuthService _authService;
    #endregion
    
    #region [생성자]
    public UserService(
        UserMapper userMapper,
        UserSetupMapper userSetupMapper,
        UserRoleMapper userRoleMapper,
        UserMenuRoleMapper userMenuRoleMapper,
        MenuRoleMapper menuRoleMapper,
        EmployeeMapper employeeMapper,
        WorkHistoryMapper workHistoryMapper,
        NotificationMapper notificationMapper,
        EmployeeService employeeService,
        AuthService authService
    )
    {
        _userMapper = userMapper;
        _userSetupMapper = userSetupMapper;
        _userRoleMapper = userRoleMapper;
        _userMenuRoleMapper = userMenuRoleMapper;
        _menuRoleMapper = menuRoleMapper;
        _employeeMapper = employeeMapper;
        _workHistoryMapper = workHistoryMapper;
        _notificationMapper = notificationMapper;
        _employeeService = employeeService;
        _authService = authService;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 사용자 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<UserResponseDTO>> ListUser(GetUserRequestDTO? dto)
        => await _userMapper.ListUser(dto);

    /// <summary>
    /// 사용자를 조회한다.
    /// </summary>
    [Transaction]
    public async Task<UserResponseDTO?> GetUser(GetUserRequestDTO dto)
    {
        var user = await _userMapper.GetUser(dto);
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
    /// 사용자 설정을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<UserSetupResponseDTO> GetUserSetup(GetUserSetupRequestDTO dto)
        => await _userSetupMapper.GetUserSetup(dto);

    /// <summary>
    /// 사용자 설정을 추가한다.
    /// </summary>
    [Transaction]
    public async Task<UserSetupResponseDTO> AddUserSetup(AddUserSetupRequestDTO dto)
    {
        var userSetupId = await _userSetupMapper.AddUserSetup(dto);
        return await _userSetupMapper.GetUserSetup(new GetUserSetupRequestDTO { UserSetupId = userSetupId });
    }

    /// <summary>
    /// 사용자를 추가한다.
    /// </summary>
    [Transaction]
    public async Task<UserResponseDTO?> AddUser(AddUserRequestDTO dto)
    {
        // 1. 사용자 중복 체크를 한다.
        var foundUser = await GetUser(new GetUserRequestDTO { UserAccount = dto.UserAccount });
        if (foundUser != null)
            throw new BizException("해당 사용자는 이미 존재해요. 입력하신 정보를 다시 확인하세요.");

        // 2. 직원 이메일주소 중복 체크를 한다.
        var foundEmailCount = await _employeeMapper.CountEmployeeEmailAddr(dto.Employee!.EmailAddr!, null);
        if (foundEmailCount > 0)
            throw new BizException("이메일주소가 이미 있어요. 입력하신 정보를 다시 확인하세요.");

        // 3. 비밀번호를 암호화한다.
        dto.UserPassword = EncryptUtil.Encrypt(dto.UserPassword!);
        dto.CreaterId = _authService.GetAuthenticatedUser().UserId; // 등록자 ID

        // 4. 사용자를 추가한다.
        var userId = await _userMapper.AddUser(dto);

        // 5. 사용자 권한을 추가한다.
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
        await _userRoleMapper.AddUserRole(addUserRoleRequestDTOList);

        // 6. 메뉴 권한 목록을 조회한다.
        var menuRoleList = await _menuRoleMapper.ListMenuRole(new GetMenuRoleRequestDTO { UserId = userId });

        // 7. 사용자 메뉴 권한을 추가한다.
        List<AddUserMenuRoleRequestDTO> addUserMenuRoleRequestDTOList = [];
        foreach (var i in menuRoleList)
        {
            addUserMenuRoleRequestDTOList.Add(new AddUserMenuRoleRequestDTO
            {
                UserId = userId,
                MenuId = i.MenuId,
                RoleId = i.RoleId,
                CreaterId = dto.CreaterId
            });
        }
        await _userMenuRoleMapper.AddUserMenuRole(addUserMenuRoleRequestDTOList);

        // 8. 직원을 추가한다.
        if (dto.Employee != null)
        {
            dto.Employee.UserId = userId;
            dto.Employee.CreaterId = dto.CreaterId;
            var employeeId = await _employeeMapper.AddEmployee(dto.Employee);

            // 9. 사용자 설정을 추가한다.
            await _userSetupMapper.AddUserSetup(new AddUserSetupRequestDTO
            {
                UserId = userId,
                SiteTitleName = $"{dto.Employee.EmployeeName}의 workspace"
            });

            // 10. 근무이력을 추가한다.
            if (dto.Employee.WorkHistory != null)
            {
                dto.Employee.WorkHistory.EmployeeId = employeeId;
                dto.Employee.WorkHistory.CreaterId = dto.CreaterId;
                
                await _employeeService.AddWorkHistory(dto.Employee.WorkHistory);
            }
        }

        // 11. 추가한 사용자를 조회해서 반환한다.
        var addedUser = await GetUser(new GetUserRequestDTO { UserId = userId });
        if (addedUser != null)
        {
            addedUser.Roles = await _userRoleMapper.ListUserRole(new GetUserRoleRequestDTO { UserId = userId });
        }
        return addedUser;
    }

    /// <summary>
    /// 사용자를 수정한다.
    /// </summary>
    [Transaction]
    public async Task<UserResponseDTO?> UpdateUser(UpdateUserRequestDTO dto)
    {
        // 1. 직원 이메일주소 중복 체크를 한다.
        var foundEmailCount = await _employeeMapper.CountEmployeeEmailAddr(dto.Employee!.EmailAddr!, dto.Employee.EmployeeId);
        if (foundEmailCount > 0)
            throw new BizException("이메일주소가 이미 있어요. 입력하신 정보를 다시 확인하세요.");

        var user = _authService.GetAuthenticatedUser();
        dto.UpdaterId = user.UserId;
        
        // 2. 사용자를 수정한다.
        await _userMapper.UpdateUser(dto);

        // 3. 사용자 권한을 삭제한다.
        await _userRoleMapper.RemoveUserRole(dto.UserId);

        // 4. 사용자 권한을 추가한다.
        List<AddUserRoleRequestDTO> addUserRoleRequestDTOList = [];
        foreach (var roleId in dto.Roles!)
        {
            addUserRoleRequestDTOList.Add(new AddUserRoleRequestDTO
            {
                UserId = dto.UserId,
                RoleId = roleId,
                CreaterId = dto.UpdaterId
            });
        }
        await _userRoleMapper.AddUserRole(addUserRoleRequestDTOList);

        // 5. 사용자 메뉴 권한을 삭제한다.
        await _userMenuRoleMapper.RemoveUserMenuRole(new RemoveUserMenuRoleRequestDTO { UserId = dto.UserId });

        // 6. 메뉴 권한 목록을 조회한다.
        var menuRoleList = await _menuRoleMapper.ListMenuRole(new GetMenuRoleRequestDTO { UserId = dto.UserId });

        // 7. 사용자 메뉴 권한을 추가한다.
        List<AddUserMenuRoleRequestDTO> addUserMenuRoleRequestDTOList = [];
        foreach (var i in menuRoleList)
        {
            addUserMenuRoleRequestDTOList.Add(new AddUserMenuRoleRequestDTO
            {
                UserId = dto.UserId,
                MenuId = i.MenuId,
                RoleId = i.RoleId,
                CreaterId = dto.UpdaterId
            });
        }
        await _userMenuRoleMapper.AddUserMenuRole(addUserMenuRoleRequestDTOList);

        // 8. 직원을 수정한다.
        if (dto.Employee != null)
        {
            dto.Employee.UpdaterId = dto.UpdaterId;
            
            await _employeeMapper.UpdateEmployee(dto.Employee);

            // 9. 근무이력을 수정한다.
            if (dto.Employee.WorkHistory != null)
            {
                dto.Employee.WorkHistory.EmployeeId = dto.Employee.EmployeeId;
                dto.Employee.WorkHistory.UpdaterId = dto.UpdaterId;
                
                await _employeeService.SaveWorkHistory(dto.Employee.WorkHistory);
            }
        }

        // 10. 수정한 사용자를 조회해서 반환한다.
        return await GetUser(new GetUserRequestDTO { UserId = dto.UserId });
    }

    /// <summary>
    /// 사용자 비밀번호를 변경한다.
    /// </summary>
    [Transaction]
    public async Task<int> UpdateUserPassword(UpdateUserPasswordRequestDTO dto)
    {
        // 1. DB의 현재 비밀번호를 조회해서
        var currentHashedPassword = await _userMapper.GetUserPassword(dto.UserId);

        // 2. 입력받은 현재 비밀번호와 동일한지 확인하고
        if (!EncryptUtil.Verify(dto.CurrentPassword!, currentHashedPassword!))
            throw new BizException("현재 비밀번호를 확인하세요.");

        // 3. 새 비밀번호와 확인용 새 비밀번호가 동일한지 확인하고
        if (dto.NewPassword != dto.NewPasswordConfirm)
            throw new BizException("새 비밀번호를 확인하세요.");

        // 4. 새 비밀번호를 암호화한다.
        dto.NewPassword = EncryptUtil.Encrypt(dto.NewPassword!);

        var updateCount = await _userMapper.UpdateUserPassword(dto);
        if (updateCount > 0)
        {
            // 5. 임시 비밀번호 변경 알림을 삭제한다.
            await _notificationMapper.RemoveNotification(new SaveNotificationRequestDTO
            {
                UpdaterId = dto.UserId,
                UserId = dto.UserId,
                NotificationKindCode = "CHANGE_PW",
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
        return await _userMapper.RemoveUser(userId, user.UserId);
    }
    #endregion
    
}
