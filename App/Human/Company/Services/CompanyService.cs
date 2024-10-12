using SmartSql.AOP;
using Svc.App.Human.Company.Mappers;
using Svc.App.Human.Company.Models.DTO;

namespace Svc.App.Human.Company.Services;

/// <summary>
/// 회사 서비스 클래스
/// </summary>
public class CompanyService
{
    #region Fields
    private readonly ICompanyMapper _companyMapper;
    #endregion
    
    #region Constructor
    public CompanyService(ICompanyMapper companyMapper)
    {
        _companyMapper = companyMapper;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 회사 목록을 조회한다.
    /// </summary>
    [Transaction]
    public async Task<IList<CompanyResponseDTO>> ListCompany(GetCompanyRequestDTO? dto)
        => await _companyMapper.ListCompany(dto);
    #endregion
    
}

