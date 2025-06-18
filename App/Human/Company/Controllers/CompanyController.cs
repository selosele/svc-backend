using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Svc.App.Common.Auth.Services;
using Svc.App.Human.Company.Models.DTO;
using Svc.App.Human.Company.Services;
using Svc.App.Shared.Utils;

namespace Svc.App.Human.Company.Controllers;

/// <summary>
/// 회사 컨트롤러 클래스
/// </summary>
[ApiController]
[Route("hm/companies")]
public class CompanyController : ControllerBase
{
    #region [필드]
    private readonly AuthService _authService;
    private readonly CompanyService _companyService;
    #endregion
    
    #region [생성자]
    public CompanyController(
        AuthService authService,
        CompanyService companyService
    ) {
        _authService = authService;
        _companyService = companyService;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 회사 목록을 조회한다.
    /// </summary>
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<CompanyResponseDTO>> ListCompany([FromQuery] GetCompanyRequestDTO? dto)
    {
        var companyList = await _companyService.ListCompany(dto);
        return Ok(new CompanyResponseDTO { CompanyList = companyList });
    }

    /// <summary>
    /// 회사를 조회한다.
    /// </summary>
    [HttpGet("{companyId}")]
    [Authorize]
    public async Task<ActionResult<CompanyResponseDTO>> GetCompany(int companyId)
    {
        var company = await _companyService.GetCompany(companyId);
        return Ok(new CompanyResponseDTO { Company = company });
    }

    /// <summary>
    /// 회사를 추가한다.
    /// </summary>
    [HttpPost]
    [Authorize(Roles = RoleUtil.SYSTEM_ADMIN)]
    public async Task<ActionResult<CompanyResponseDTO>> AddCompany([FromBody] SaveCompanyRequestDTO saveCompanyRequestDTO)
    {
        var user = _authService.GetAuthenticatedUser();
        var myUserId = user.UserId;

        saveCompanyRequestDTO.CreaterId = myUserId;

        var company = await _companyService.AddCompany(saveCompanyRequestDTO);
        return Created(string.Empty, new CompanyResponseDTO { Company = company });
    }

    /// <summary>
    /// 회사를 수정한다.
    /// </summary>
    [HttpPut("{companyId}")]
    [Authorize(Roles = RoleUtil.SYSTEM_ADMIN)]
    public async Task<ActionResult<int>> UpdateCompany(int companyId, [FromBody] SaveCompanyRequestDTO saveCompanyRequestDTO)
    {
        var user = _authService.GetAuthenticatedUser();
        var myUserId = user.UserId;

        saveCompanyRequestDTO.UpdaterId = myUserId;

        return Ok(await _companyService.UpdateCompany(saveCompanyRequestDTO));
    }

    /// <summary>
    /// 회사를 삭제한다.
    /// </summary>
    [HttpDelete("{companyId}")]
    [Authorize(Roles = RoleUtil.SYSTEM_ADMIN)]
    public async Task<ActionResult> RemoveCompany(int companyId)
    {
        var user = _authService.GetAuthenticatedUser();
        var myUserId = user.UserId;

        await _companyService.RemoveCompany(companyId, myUserId);
        return NoContent();
    }
    #endregion

}
