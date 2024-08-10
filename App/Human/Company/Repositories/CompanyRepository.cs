using SmartSql;
using svc.App.Human.Company.Models.DTO;

namespace svc.App.Human.Company.Repositories;

/// <summary>
/// 회사 리포지토리 클래스
/// </summary>
public class CompanyRepository : ICompanyRepository
{
    #region Fields
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region Constructor
    public CompanyRepository(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 회사 목록을 조회한다.
    /// </summary>
    public Task<IList<CompanyResponseDTO>> ListCompany(GetCompanyRequestDTO? getCompanyRequestDTO)
    {
        return SqlMapper.QueryAsync<CompanyResponseDTO>(new RequestContext
        {
            Scope = nameof(CompanyRepository),
            SqlId = "ListCompany",
            Request = getCompanyRequestDTO
        });
    }
    #endregion

}
