using SmartSql;
using Svc.App.Shared.Mappers;
using Svc.App.Human.Company.Models.DTO;

namespace Svc.App.Human.Company.Mappers;

/// <summary>
/// 회사 매퍼 클래스
/// </summary>
public class CompanyMapper : MyMapperBase
{
    #region [생성자]
    public CompanyMapper(ISqlMapper sqlMapper) : base(sqlMapper) {}
    #endregion

    #region [메서드]
    /// <summary>
    /// 회사 목록을 조회한다.
    /// </summary>
    public Task<IList<CompanyResultDTO>> ListCompany(GetCompanyRequestDTO? dto)
        => QueryForList<CompanyResultDTO>($"{nameof(CompanyMapper)}.ListCompany", dto);

    /// <summary>
    /// 회사를 조회한다.
    /// </summary>
    public Task<CompanyResultDTO> GetCompany(int companyId)
        => QueryForObject<CompanyResultDTO>($"{nameof(CompanyMapper)}.GetCompany", new { companyId });

    /// <summary>
    /// 회사 정보가 존재하는지 확인한다.
    /// </summary>
    public Task<int> CountCompany(GetCompanyRequestDTO dto)
        => QueryForObject<int>($"{nameof(CompanyMapper)}.CountCompany", dto);

    /// <summary>
    /// 회사를 추가한다.
    /// </summary>
    public Task<int> AddCompany(SaveCompanyRequestDTO dto)
        => ExecuteScalar<int>($"{nameof(CompanyMapper)}.AddCompany", dto);

    /// <summary>
    /// 회사를 수정한다.
    /// </summary>
    public Task<int> UpdateCompany(SaveCompanyRequestDTO dto)
        => Execute($"{nameof(CompanyMapper)}.UpdateCompany", dto);

    /// <summary>
    /// 회사를 삭제한다.
    /// </summary>
    public Task<int> RemoveCompany(int companyId, int? updaterId)
        => Execute($"{nameof(CompanyMapper)}.RemoveCompany", new { companyId, updaterId });
    #endregion

}
