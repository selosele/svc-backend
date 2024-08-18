using Svc.App.Human.Employee.Models.DTO;

namespace Svc.App.Human.Employee.Repositories;

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
    /// 직원 회사를 조회한다.
    /// </summary>
    Task<EmployeeCompanyResponseDTO> GetEmployeeCompany(GetEmployeeCompanyRequestDTO getEmployeeCompanyRequestDTO);

    /// <summary>
    /// 직원 회사를 추가한다.
    /// </summary>
    Task<int> AddEmployeeCompany(SaveEmployeeCompanyRequestDTO SaveEmployeeCompanyRequestDTO);
    
    /// <summary>
    /// 직원 회사를 수정한다.
    /// </summary>
    Task<int> UpdateEmployeeCompany(SaveEmployeeCompanyRequestDTO SaveEmployeeCompanyRequestDTO);

    /// <summary>
    /// 직원 회사를 삭제한다.
    /// </summary>
    Task<int> RemoveEmployeeCompany(int userId, int employeeCompanyId);
    #endregion

}
