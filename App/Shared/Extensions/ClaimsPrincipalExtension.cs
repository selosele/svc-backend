using System.Security.Claims;
using Svc.App.Common.User.Models.DTO;
using Svc.App.Human.Employee.Models.DTO;
using Svc.App.Shared.Utils;

namespace Svc.App.Shared.Extensions;

/// <summary>
/// ClaimsPrincipal의 확장 메서드를 제공하는 클래스
/// </summary>
public static class ClaimsPrincipalExtension
{
    #region [메서드]
    /// <summary>
    /// 인증된 사용자 정보를 UserResponseDTO에 담아서 반환한다.
    /// </summary>
    public static UserResponseDTO GetUser(this ClaimsPrincipal principal)
    {
        var user = new UserResponseDTO
        {
            UserId = int.Parse(principal?.FindFirstValue(ClaimUtil.USER_ID_IDENTIFIER)!),
            UserAccount = principal?.FindFirstValue(ClaimUtil.USER_ACCOUNT_IDENTIFIER),
            Employee = new EmployeeResponseDTO
            {
                EmployeeId = int.Parse(principal?.FindFirstValue(ClaimUtil.EMPLOYEE_ID_IDENTIFIER)!),
                EmployeeName = principal?.FindFirstValue(ClaimUtil.EMPLOYEE_NAME_IDENTIFIER),
                WorkHistories = [
                    new WorkHistoryResponseDTO
                    {
                        WorkHistoryId = int.Parse(principal?.FindFirstValue(ClaimUtil.WORK_HISTORY_ID_IDENTIFIER)!),
                        CompanyName = principal?.FindFirstValue(ClaimUtil.COMPANY_NAME_IDENTIFIER),
                        RankCode = principal?.FindFirstValue(ClaimUtil.RANK_CODE_IDENTIFIER),
                        RankCodeName = principal?.FindFirstValue(ClaimUtil.RANK_CODE_NAME_IDENTIFIER),
                        JobTitleCode = principal?.FindFirstValue(ClaimUtil.JOB_TITLE_CODE_IDENTIFIER),
                        JobTitleCodeName = principal?.FindFirstValue(ClaimUtil.JOB_TITLE_CODE_NAME_IDENTIFIER),
                        JoinYmd = principal?.FindFirstValue(ClaimUtil.JOIN_YMD_IDENTIFIER),
                        QuitYmd = principal?.FindFirstValue(ClaimUtil.QUIT_YMD_IDENTIFIER),
                    }
                ]
            }
        };

        // Claims로부터 권한 목록을 추출해서
        var roleList = principal?.Claims
            .Where(x => x.Type == ClaimTypes.Role) // ClaimUtil.ROLES_IDENTIFIER 값이 아닌 ClaimTypes.Role 값이 들어가 있음
            .Select(x => x.Value)
            .ToList();

        // UserResponseDTO의 권한 목록에 담아준다.
        foreach (var roleId in roleList!)
        {
            user.Roles?.Add(new UserRoleResponseDTO { RoleId = roleId, UserId = user.UserId });
        }
        
        return user;
    }
    #endregion

}