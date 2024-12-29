using SmartSql;
using Svc.App.Human.Company.Models.DTO;

namespace Svc.App.Human.Company.Mappers;

/// <summary>
/// 회사등록신청 매퍼 클래스
/// </summary>
public class CompanyApplyMapper
{
    #region [필드]
    public ISqlMapper SqlMapper { get; }
    #endregion

    #region [생성자]
    public CompanyApplyMapper(ISqlMapper sqlMapper)
    {
        SqlMapper = sqlMapper;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 회사등록신청 목록을 조회한다.
    /// </summary>
    public Task<IList<CompanyApplyResponseDTO>> ListCompanyApply(GetCompanyApplyRequestDTO? dto)
    {
        return SqlMapper.QueryAsync<CompanyApplyResponseDTO>(new RequestContext
        {
            Scope = nameof(CompanyApplyMapper),
            SqlId = "ListCompanyApply",
            Request = dto
        });
    }

    /// <summary>
    /// 회사등록신청을 조회한다.
    /// </summary>
    public Task<CompanyApplyResponseDTO> GetCompanyApply(int companyApplyId)
    {
        return SqlMapper.QuerySingleAsync<CompanyApplyResponseDTO>(new RequestContext
        {
            Scope = nameof(CompanyApplyMapper),
            SqlId = "GetCompanyApply",
            Request = new { companyApplyId }
        });
    }

    /// <summary>
    /// 회사등록신청을 추가한다.
    /// </summary>
    public Task<int> AddCompanyApply(SaveCompanyApplyRequestDTO dto)
    {
        return SqlMapper.ExecuteScalarAsync<int>(new RequestContext
        {
            Scope = nameof(CompanyApplyMapper),
            SqlId = "AddCompanyApply",
            Request = dto
        });
    }

    /// <summary>
    /// 회사등록신청을 수정한다.
    /// </summary>
    public Task<int> UpdateCompanyApply(SaveCompanyApplyRequestDTO dto)
    {
        return SqlMapper.ExecuteAsync(new RequestContext
        {
            Scope = nameof(CompanyApplyMapper),
            SqlId = "UpdateCompanyApply",
            Request = dto
        });
    }
    #endregion

}
