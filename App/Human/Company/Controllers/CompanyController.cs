using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Svc.App.Human.Company.Models.DTO;
using Svc.App.Human.Company.Services;

namespace Svc.App.Human.Company.Controllers;

/// <summary>
/// 회사 컨트롤러 클래스
/// </summary>
[ApiController]
[Route("api/hm/companies")]
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
    public async Task<ActionResult<List<CompanyResponseDTO>>> ListCompany([FromQuery] GetCompanyRequestDTO? dto)
        => Ok(await _companyService.ListCompany(dto));

    /// <summary>
    /// 금융위원회_기업기본정보 - 기업개요조회 API로 회사 목록을 조회한다.
    /// </summary>
    [HttpGet("openapi")]
    [Authorize]
    public async Task<ActionResult<List<CompanyResponseDTO>>> ListCompanyOpenAPI([FromQuery] GetCompanyRequestDTO? dto)
        => Ok(await _companyService.ListCompanyOpenAPI(dto));
    #endregion

}
