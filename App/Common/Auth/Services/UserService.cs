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
        _employeeService = employeeService;
        _authService = authService;
    }
    #endregion

    #region Methods
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
        addUserRequestDTO.CreaterId = int.Parse(_authService.GetAuthenticatedUser()?.FindFirstValue(ClaimUtil.USER_ID_IDENTIFIER)!);

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

        var user = _authService.GetAuthenticatedUser();
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
        var user = _authService.GetAuthenticatedUser();
        var myUserId = int.Parse(user?.FindFirstValue(ClaimUtil.USER_ID_IDENTIFIER)!);
        
        return await _userRepository.RemoveUser(userId, myUserId);
    }
    #endregion
    
}
