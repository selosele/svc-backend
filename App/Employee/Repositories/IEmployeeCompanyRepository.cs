using svc.App.Employee.Models.DTO;

namespace svc.App.Employee.Repositories;

/// <summary>
/// 직원 회사 리포지토리 인터페이스
/// </summary>
public interface IEmployeeCompanyRepository
{
    #region Methods
    /// <summary>
    /// 직원의 재직 중인 회사를 조회한다.
    /// </summary>
    Task<EmployeeCompanyResponseDTO> GetEmployeeCompany(int? employeeId);
    #endregion

}
