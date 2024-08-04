using SmartSql;
using svc.App.Human.Employee.Models.DTO;

namespace svc.App.Human.Employee.Repositories;

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
    public Task<EmployeeResponseDTO> GetEmployee(GetEmployeeRequestDTO getEmployeeRequestDTO)
    {
        return SqlMapper.QuerySingleAsync<EmployeeResponseDTO>(new RequestContext
        {
            Scope = nameof(EmployeeRepository),
            SqlId = "GetEmployee",
            Request = getEmployeeRequestDTO
        });
    }

    /// <summary>
    /// 직원을 수정한다.
    /// </summary>
    public Task<int> UpdateEmployee(UpdateEmployeeRequestDTO updateEmployeeRequestDTO)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(EmployeeRepository),
            SqlId = "UpdateEmployee",
            Request = updateEmployeeRequestDTO
        });
    }
    #endregion

}
