using SmartSql;
using Svc.App.Human.Employee.Models.DTO;

namespace Svc.App.Human.Employee.Repositories;

/// <summary>
/// 직원 리포지토리 클래스
/// </summary>
public class EmployeeRepository : IEmployeeRepository
{
    #region Fields
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region Constructor
    public EmployeeRepository(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 직원을 조회한다.
    /// </summary>
    public Task<EmployeeResponseDTO> GetEmployee(GetEmployeeRequestDTO dto)
    {
        return SqlMapper.QuerySingleAsync<EmployeeResponseDTO>(new RequestContext
        {
            Scope = nameof(EmployeeRepository),
            SqlId = "GetEmployee",
            Request = dto
        });
    }

    /// <summary>
    /// 직원을 추가한다.
    /// </summary>
    public Task<int> AddEmployee(AddEmployeeRequestDTO dto)
    {
        return SqlMapper.ExecuteScalarAsync<int>(new RequestContext
        {
            Scope = nameof(EmployeeRepository),
            SqlId = "AddEmployee",
            Request = dto
        });
    }

    /// <summary>
    /// 직원을 수정한다.
    /// </summary>
    public Task<int> UpdateEmployee(UpdateEmployeeRequestDTO dto)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(EmployeeRepository),
            SqlId = "UpdateEmployee",
            Request = dto
        });
    }

    /// <summary>
    /// 직원 이메일주소 중복 체크를 한다.
    /// </summary>
    public Task<int> CountEmployeeEmailAddr(string emailAddr, int? employeeId)
    {
        return SqlMapper.QuerySingleAsync<int>(new RequestContext
        {
            Scope = nameof(EmployeeRepository),
            SqlId = "CountEmployeeEmailAddr",
            Request = new { emailAddr, employeeId }
        });
    }
    #endregion

}
