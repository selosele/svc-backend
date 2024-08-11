using SmartSql;
using svc.App.Human.Department.Models.DTO;

namespace svc.App.Human.Department.Repositories;

/// <summary>
/// 부서 리포지토리 클래스
/// </summary>
public class DepartmentRepository : IDepartmentRepository
{
    #region Fields
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region Constructor
    public DepartmentRepository(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 부서 목록을 조회한다.
    /// </summary>
    public Task<IList<DepartmentResponseDTO>> ListDepartment(GetDepartmentRequestDTO getDepartmentRequestDTO)
    {
        return SqlMapper.QueryAsync<DepartmentResponseDTO>(new RequestContext
        {
            Scope = nameof(DepartmentRepository),
            SqlId = "ListDepartment",
            Request = getDepartmentRequestDTO
        });
    }

    /// <summary>
    /// 회사별 부서 목록을 조회한다.
    /// </summary>
    public Task<IList<DepartmentResponseDTO>> ListDepartmentByCompany(GetDepartmentRequestDTO? getDepartmentRequestDTO)
    {
        return SqlMapper.QueryAsync<DepartmentResponseDTO>(new RequestContext
        {
            Scope = nameof(DepartmentRepository),
            SqlId = "ListDepartmentByCompany",
            Request = getDepartmentRequestDTO
        });
    }
    #endregion

}
