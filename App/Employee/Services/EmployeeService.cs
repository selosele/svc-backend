using SmartSql.AOP;
using svc.App.Auth.Services;
using svc.App.Employee.Repositories;
using svc.App.Employee.Models.DTO;

namespace svc.App.Employee.Services;

/// <summary>
/// 직원 서비스 클래스
/// </summary>
public class EmployeeService
{
    #region Fields
    private readonly AuthService _authService;
    private readonly IEmployeeRepository _employeeRepository;
    #endregion
    
    #region Constructor
    public EmployeeService(
        AuthService authService,
        IEmployeeRepository employeeRepository
    )
    {
        _authService = authService;
        _employeeRepository = employeeRepository;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 직원을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<EmployeeResponseDTO> GetEmployee(GetEmployeeRequestDTO getEmployeeRequestDTO)
    {
        return await _employeeRepository.GetEmployee(getEmployeeRequestDTO);
    }
    #endregion
    
}

