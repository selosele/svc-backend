using SmartSql;
using svc.App.Human.Department.Models.DTO;
using svc.App.Human.Employee.Models.DTO;

namespace svc.App.Human.Employee.Repositories;

/// <summary>
/// 직원 회사 리포지토리 클래스
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
    /// 직원 회사 목록을 조회한다.
    /// </summary>
    public Task<IList<EmployeeCompanyResponseDTO>> ListEmployeeCompany(int? employeeId)
    {
        return SqlMapper.QueryAsync<EmployeeCompanyResponseDTO>(new RequestContext
        {
            Scope = nameof(EmployeeCompanyRepository),
            SqlId = "ListEmployeeCompany",
            Request = new { employeeId }
        });
    }

    /// <summary>
    /// 직원 회사를 수정한다.
    /// </summary>
    public Task<int> UpdateEmployeeCompany(UpdateEmployeeCompanyRequestDTO updateEmployeeCompanyRequestDTO)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(EmployeeCompanyRepository),
            SqlId = "UpdateEmployeeCompany",
            Request = updateEmployeeCompanyRequestDTO
        });
    }

    /// <summary>
    /// 직원 부서를 수정한다.
    /// </summary>
    public Task<int> UpdateEmployeeDepartment(UpdateDepartmentRequestDTO updateDepartmentRequestDTO)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(EmployeeCompanyRepository),
            SqlId = "UpdateEmployeeDepartment",
            Request = updateDepartmentRequestDTO
        });
    }
    #endregion

}
