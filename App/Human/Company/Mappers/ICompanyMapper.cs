using Svc.App.Human.Company.Models.DTO;

namespace Svc.App.Human.Company.Mappers;

/// <summary>
/// 회사 매퍼 인터페이스
/// </summary>
public interface ICompanyMapper
{
    #region Methods
    /// <summary>
    /// 회사 목록을 조회한다.
    /// </summary>
    Task<IList<CompanyResponseDTO>> ListCompany(GetCompanyRequestDTO? dto);
    #endregion

}
