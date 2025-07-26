using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Svc.App.Common.Auth.Services;
using Svc.App.Human.Company.Models.DTO;
using Svc.App.Human.Company.Services;
using Svc.App.Shared.Utils;

namespace Svc.App.Human.Company.Controllers;

/// <summary>
/// 회사등록신청 API
/// </summary>
[ApiController]
[Route("api/hm/company-applies")]
public class CompanyApplyController(
    AuthService authService,
    CompanyService companyService
    ) : ControllerBase
{
    #region [필드]
    private readonly AuthService _authService = authService;
    private readonly CompanyService _companyService = companyService;
    #endregion

    #region [메서드]
    /// <summary>
    /// 회사등록신청 목록을 조회한다.
    /// </summary>
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<CompanyApplyResponseDTO>> ListCompanyApply([FromQuery] GetCompanyApplyRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        if (!_authService.HasRole(RoleUtil.SYSTEM_ADMIN))
            dto.ApplicantId = user.UserId;

        var companyApplyList = await _companyService.ListCompanyApply(dto);
        return Ok(new CompanyApplyResponseDTO { CompanyApplyList = companyApplyList });
    }

    /// <summary>
    /// 회사등록신청을 조회한다.
    /// </summary>
    [HttpGet("{companyApplyId}")]
    [Authorize]
    public async Task<ActionResult<CompanyApplyResponseDTO>> GetCompanyApply(int companyApplyId)
    {
        var companyApply = await _companyService.GetCompanyApply(companyApplyId);
        return Ok(new CompanyApplyResponseDTO { CompanyApply = companyApply });
    }

    /// <summary>
    /// 회사등록신청을 추가한다.
    /// </summary>
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<CompanyApplyResponseDTO>> AddCompanyApply([FromBody] SaveCompanyApplyRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        dto.CreaterId = user.UserId;
        dto.ApplyStateCode = "NEW";

        var companyApply = await _companyService.AddCompanyApply(dto);
        return Created(string.Empty, new CompanyApplyResponseDTO { CompanyApply = companyApply });
    }

    /// <summary>
    /// 회사등록신청을 수정한다.
    /// </summary>
    [HttpPut("{companyApplyId}")]
    [Authorize]
    public async Task<ActionResult<int>> UpdateCompanyApply(int companyApplyId, [FromBody] SaveCompanyApplyRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        dto.UpdaterId = user.UserId;

        return Ok(await _companyService.UpdateCompanyApply(dto));
    }
    #endregion

}
