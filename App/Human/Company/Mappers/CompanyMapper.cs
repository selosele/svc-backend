using SmartSql;
using Svc.App.Human.Company.Models.DTO;

namespace Svc.App.Human.Company.Mappers;

/// <summary>
/// 회사 매퍼 클래스
/// </summary>
public class CompanyMapper
{
    #region [필드]
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region [생성자]
    public CompanyMapper(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region [메서드]
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

    /// <summary>
    /// 회사를 조회한다.
    /// </summary>
    public Task<CompanyResponseDTO> GetCompany(int companyId)
    {
        return SqlMapper.QuerySingleAsync<CompanyResponseDTO>(new RequestContext
        {
            Scope = nameof(CompanyMapper),
            SqlId = "GetCompany",
            Request = new { companyId }
        });
    }

    /// <summary>
    /// 회사 정보가 존재하는지 확인한다.
    /// </summary>
    public Task<int> CountCompany(GetCompanyRequestDTO dto)
    {
        return SqlMapper.QuerySingleAsync<int>(new RequestContext
        {
            Scope = nameof(CompanyMapper),
            SqlId = "CountCompany",
            Request = dto
        });
    }

    /// <summary>
    /// 회사를 추가한다.
    /// </summary>
    public Task<int> AddCompany(SaveCompanyRequestDTO dto)
    {
        return SqlMapper.ExecuteScalarAsync<int>(new RequestContext
        {
            Scope = nameof(CompanyMapper),
            SqlId = "AddCompany",
            Request = dto
        });
    }

    /// <summary>
    /// 회사를 수정한다.
    /// </summary>
    public Task<int> UpdateCompany(SaveCompanyRequestDTO dto)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(CompanyMapper),
            SqlId = "UpdateCompany",
            Request = dto
        });
    }

    /// <summary>
    /// 회사를 삭제한다.
    /// </summary>
    public Task<int> RemoveCompany(int companyId, int? updaterId)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(CompanyMapper),
            SqlId = "RemoveCompany",
            Request = new { companyId, updaterId }
        });
    }
    #endregion

}
