using SmartSql.AOP;
using svc.App.Human.Company.Repositories;
using svc.App.Human.Company.Models.DTO;

namespace svc.App.Human.Company.Services;

/// <summary>
/// 회사 서비스 클래스
/// </summary>
public class CompanyService
{
    #region Fields
    private readonly ICompanyRepository _companyRepository;
    #endregion
    
    #region Constructor
    public CompanyService(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 회사 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<CompanyResponseDTO>> ListCompany(GetCompanyRequestDTO? getCompanyRequestDTO)
        => await _companyRepository.ListCompany(getCompanyRequestDTO);
    #endregion
    
}
