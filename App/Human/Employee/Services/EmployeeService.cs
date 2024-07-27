using SmartSql.AOP;
using svc.App.Human.Department.Models.DTO;
using svc.App.Human.Department.Repositories;
using svc.App.Human.Employee.Models.DTO;
using svc.App.Human.Employee.Repositories;

namespace svc.App.Human.Employee.Services;

/// <summary>
/// 직원 서비스 클래스
/// </summary>
public class EmployeeService
{
    #region Fields
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IEmployeeCompanyRepository _employeeCompanyRepository;
    private readonly IDepartmentRepository _departmentRepository;
    #endregion
    
    #region Constructor
    public EmployeeService(
        IEmployeeRepository employeeRepository,
        IEmployeeCompanyRepository employeeCompanyRepository,
        IDepartmentRepository departmentRepository
    )
    {
        _employeeRepository = employeeRepository;
        _employeeCompanyRepository = employeeCompanyRepository;
        _departmentRepository = departmentRepository;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 직원을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<EmployeeResponseDTO?> GetEmployee(GetEmployeeRequestDTO getEmployeeRequestDTO)
    {
        var employee = await _employeeRepository.GetEmployee(getEmployeeRequestDTO);
        if (employee != null)
        {
            employee.EmployeeCompanies = await _employeeCompanyRepository.ListEmployeeCompany(employee.EmployeeId);
            employee.Departments = await _departmentRepository.ListDepartment(new GetDepartmentRequestDTO { EmployeeId = employee.EmployeeId });
        }
        return employee;
    }
    #endregion
    
}

