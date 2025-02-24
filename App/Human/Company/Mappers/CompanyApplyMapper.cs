using SmartSql;
using Svc.App.Shared.Mappers;
using Svc.App.Human.Company.Models.DTO;

namespace Svc.App.Human.Company.Mappers;

/// <summary>
/// 회사등록신청 매퍼 클래스
/// </summary>
public class CompanyApplyMapper : MyMapperBase
{
    #region [생성자]
    public CompanyApplyMapper(ISqlMapper sqlMapper) : base(sqlMapper) {}
    #endregion

    #region [메서드]
    /// <summary>
    /// 회사등록신청 목록을 조회한다.
    /// </summary>
    public Task<IList<CompanyApplyResultDTO>> ListCompanyApply(GetCompanyApplyRequestDTO? dto)
        => QueryForList<CompanyApplyResultDTO>($"{nameof(CompanyApplyMapper)}.ListCompanyApply", dto);

    /// <summary>
    /// 회사등록신청을 조회한다.
    /// </summary>
    public Task<CompanyApplyResultDTO> GetCompanyApply(int companyApplyId)
        => QueryForObject<CompanyApplyResultDTO>($"{nameof(CompanyApplyMapper)}.GetCompanyApply", new { companyApplyId });

    /// <summary>
    /// 회사등록신청을 추가한다.
    /// </summary>
    public Task<int> AddCompanyApply(SaveCompanyApplyRequestDTO dto)
        => ExecuteScalar<int>($"{nameof(CompanyApplyMapper)}.AddCompanyApply", dto);

    /// <summary>
    /// 회사등록신청을 수정한다.
    /// </summary>
    public Task<int> UpdateCompanyApply(SaveCompanyApplyRequestDTO dto)
        => Execute($"{nameof(CompanyApplyMapper)}.UpdateCompanyApply", dto);
    #endregion

}
