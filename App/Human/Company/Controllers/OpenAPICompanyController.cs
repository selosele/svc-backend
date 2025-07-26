using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Svc.App.Human.Company.Models.DTO;
using Svc.App.Human.Company.Services;

namespace Svc.App.Human.Company.Controllers;

/// <summary>
/// 회사(Open API 사용) API
/// </summary>
[ApiController]
[Route("api/public/hm/companies")]
public class OpenAPICompanyController(CompanyService companyService) : ControllerBase
{
    #region [필드]
    private readonly CompanyService _companyService = companyService;
    #endregion

    #region [메서드]
    /// <summary>
    /// 금융위원회_기업기본정보 - 기업개요조회 API로 회사 목록을 조회한다.
    /// </summary>
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<CompanyOpenAPIResponseDTO>>> ListCompany([FromQuery] GetCompanyRequestDTO? dto)
        => Ok(await _companyService.ListCompanyOpenAPI(dto));
    #endregion

}
