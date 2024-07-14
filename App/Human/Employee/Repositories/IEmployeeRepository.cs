using svc.App.Human.Employee.Models.DTO;

namespace svc.App.Human.Employee.Repositories;

/// <summary>
/// 직원 리포지토리 인터페이스
/// </summary>
public interface IEmployeeRepository
{
    #region Methods
    /// <summary>
    /// 직원을 조회한다.
    /// </summary>
    Task<EmployeeResponseDTO> GetEmployee(GetEmployeeRequestDTO getEmployeeRequestDTO);
    #endregion

}
