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
    Task<EmployeeResponseDTO> GetEmployee(GetEmployeeRequestDTO dto);

    /// <summary>
    /// 직원을 추가한다.
    /// </summary>
    Task<int> AddEmployee(AddEmployeeRequestDTO dto);

    /// <summary>
    /// 직원을 수정한다.
    /// </summary>
    Task<int> UpdateEmployee(UpdateEmployeeRequestDTO dto);

    /// <summary>
    /// 직원 이메일주소 중복 체크를 한다.
    /// </summary>
    Task<int> CountEmployeeEmailAddr(string emailAddr, int? employeeId);
    #endregion

}
