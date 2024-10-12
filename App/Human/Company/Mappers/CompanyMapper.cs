using SmartSql;
using Svc.App.Human.Company.Models.DTO;

namespace Svc.App.Human.Company.Mappers;

/// <summary>
/// 회사 매퍼 클래스
/// </summary>
public class CompanyMapper
{
    #region Fields
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region Constructor
    public CompanyMapper(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 회사 목록을 조회한다.
    /// </summary>
    public Task<IList<CompanyResponseDTO>> ListCompany(GetCompanyRequestDTO? dto)
    {
        return SqlMapper.QueryAsync<CompanyResponseDTO>(new RequestContext
        {
            Scope = nameof(CompanyMapper),
            SqlId = "ListCompany",
            Request = dto
        });
    }
    #endregion

}
