using svc.App.Human.Department.Models.DTO;
using svc.App.Human.Employee.Models.DTO;

namespace svc.App.Human.Employee.Repositories;

/// <summary>
/// 직원 회사 리포지토리 인터페이스
/// </summary>
public interface IEmployeeCompanyRepository
{
    #region Methods
    /// <summary>
    /// 직원 회사 목록을 조회한다.
    /// </summary>
    Task<IList<EmployeeCompanyResponseDTO>> ListEmployeeCompany(int? employeeId);

    /// <summary>
    /// 직원 회사를 수정한다.
    /// </summary>
    Task<int> UpdateEmployeeCompany(UpdateEmployeeCompanyRequestDTO updateEmployeeCompanyRequestDTO);

    /// <summary>
    /// 직원 부서를 수정한다.
    /// </summary>
    Task<int> UpdateEmployeeDepartment(UpdateDepartmentRequestDTO updateDepartmentRequestDTO);
    #endregion

}
