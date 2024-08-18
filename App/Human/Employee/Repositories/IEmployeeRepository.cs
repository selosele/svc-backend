using Svc.App.Human.Employee.Models.DTO;

namespace Svc.App.Human.Employee.Repositories;

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

    /// <summary>
    /// 직원을 수정한다.
    /// </summary>
    Task<int> UpdateEmployee(UpdateEmployeeRequestDTO updateEmployeeRequestDTO);
    #endregion

}
