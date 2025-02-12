using SmartSql;
using Svc.App.Shared.Extensions;
using Svc.App.Human.Employee.Models.DTO;

namespace Svc.App.Human.Employee.Mappers;

/// <summary>
/// 직원 매퍼 클래스
/// </summary>
public class EmployeeMapper
{
    #region [필드]
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region [생성자]
    public EmployeeMapper(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 직원을 조회한다.
    /// </summary>
    public Task<EmployeeResultDTO> GetEmployee(GetEmployeeRequestDTO dto)
        => SqlMapper.QueryForObject<EmployeeResultDTO>(nameof(EmployeeMapper), "GetEmployee", dto);

    /// <summary>
    /// 직원을 추가한다.
    /// </summary>
    public Task<int> AddEmployee(AddEmployeeRequestDTO dto)
        => SqlMapper.ExecuteScalar<int>(nameof(EmployeeMapper), "AddEmployee", dto);

    /// <summary>
    /// 직원을 수정한다.
    /// </summary>
    public Task<int> UpdateEmployee(UpdateEmployeeRequestDTO dto)
        => SqlMapper.Execute(nameof(EmployeeMapper), "UpdateEmployee", dto);

    /// <summary>
    /// 직원 이메일주소 중복 체크를 한다.
    /// </summary>
    public Task<int> CountEmployeeEmailAddr(string emailAddr, int? employeeId)
        => SqlMapper.QueryForObject<int>(nameof(EmployeeMapper), "CountEmployeeEmailAddr", new { emailAddr, employeeId });
    #endregion

}
