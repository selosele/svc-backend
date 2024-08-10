using svc.App.Human.Company.Models.DTO;

namespace svc.App.Human.Company.Repositories;

/// <summary>
/// 회사 리포지토리 인터페이스
/// </summary>
public interface ICompanyRepository
{
    #region Methods
    /// <summary>
    /// 회사 목록을 조회한다.
    /// </summary>
    Task<IList<CompanyResponseDTO>> ListCompany(GetCompanyRequestDTO? getCompanyRequestDTO);
    #endregion

}
