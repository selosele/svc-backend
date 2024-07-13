using SmartSql;
using svc.App.Employee.Models.DTO;

namespace svc.App.Employee.Repositories;

/// <summary>
/// 직원 리포지토리 클래스
/// </summary>
public class EmployeeCompanyRepository : IEmployeeCompanyRepository
{
    #region Fields
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region Constructor
    public EmployeeCompanyRepository(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 직원의 재직 중인 회사를 조회한다.
    /// </summary>
    public Task<EmployeeCompanyResponseDTO> GetEmployeeCompany(int? employeeId)
    {
        return SqlMapper.QuerySingleAsync<EmployeeCompanyResponseDTO>(new RequestContext
        {
            Scope = nameof(EmployeeCompanyRepository),
            SqlId = "GetEmployeeCompany",
            Request = employeeId
        });
    }
    #endregion

}
