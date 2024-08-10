using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using svc.App.Common.Code.Models.DTO;
using svc.App.Human.Company.Models.DTO;
using svc.App.Human.Company.Services;

namespace svc.App.Human.Company.Controllers;

/// <summary>
/// 회사 컨트롤러 클래스
/// </summary>
[ApiController]
[Route("api/human/companies")]
public class CompanyController : ControllerBase
{
    #region Fields
    private readonly CompanyService _companyService;
    #endregion
    
    #region Constructor
    public CompanyController(
        CompanyService companyService
    ) {
        _companyService = companyService;
    }
    #endregion

    #region Methods
    /// <summary>
    /// 회사 목록을 조회한다.
    /// </summary>
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<CodeResponseDTO>>> ListCompany([FromQuery] GetCompanyRequestDTO? getCompanyRequestDTO)
        => Ok(await _companyService.ListCompany(getCompanyRequestDTO));
    #endregion

}
