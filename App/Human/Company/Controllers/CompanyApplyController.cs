using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Svc.App.Common.Auth.Services;
using Svc.App.Human.Company.Models.DTO;
using Svc.App.Human.Company.Services;
using Svc.App.Shared.Utils;

namespace Svc.App.Human.Company.Controllers;

/// <summary>
/// 회사등록신청 컨트롤러 클래스
/// </summary>
[ApiController]
[Route("api/hm/company-applies")]
public class CompanyApplyController : ControllerBase
{
    #region [필드]
    private readonly AuthService _authService;
    private readonly CompanyService _companyService;
    #endregion
    
    #region [생성자]
    public CompanyApplyController(
        AuthService authService,
        CompanyService companyService
    ) {
        _authService = authService;
        _companyService = companyService;
    }
    #endregion

    #region [메서드]
    /// <summary>
    /// 회사등록신청 목록을 조회한다.
    /// </summary>
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<CompanyApplyResponseDTO>>> ListCompanyApply([FromQuery] GetCompanyApplyRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        if (!user.Roles!.Any(x => x.RoleId == RoleUtil.SYSTEM_ADMIN))
            dto.ApplicantId = user.UserId;

        return Ok(await _companyService.ListCompanyApply(dto));
    }

    /// <summary>
    /// 회사등록신청을 조회한다.
    /// </summary>
    [HttpGet("{companyApplyId}")]
    [Authorize]
    public async Task<ActionResult<CompanyApplyResponseDTO>> GetCompanyApply(int companyApplyId)
        => Ok(await _companyService.GetCompanyApply(companyApplyId));

    /// <summary>
    /// 회사등록신청을 추가한다.
    /// </summary>
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<int>> AddCompanyApply([FromBody] SaveCompanyApplyRequestDTO dto)
    {
        var user = _authService.GetAuthenticatedUser();
        dto.CreaterId = user.UserId;
        dto.ApplyStateCode = "NEW";

        return Created(string.Empty, await _companyService.AddCompanyApply(dto));
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
