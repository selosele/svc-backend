using System.Security.Claims;
using Svc.App.Common.User.Models.DTO;
using Svc.App.Human.Employee.Models.DTO;

namespace Svc.App.Shared.Utils;

/// <summary>
/// ClaimsPrincipal의 확장 메서드를 제공하는 유틸 클래스
/// </summary>
public static class ClaimsPrincipalUtil
{
    #region Methods
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
                    }
                ]
            }
        };

        // TODO: 로그인시 user.Roles에 권한 정보가 담기지만, API 호출시 user.Roles에 요소가 없음
        // var roleList = principal?.Claims
        //     .Where(x => x.Type == ClaimUtil.ROLES_IDENTIFIER)
        //     .Select(x => x.Value)
        //     .ToList();

        // foreach (var roleId in roleList!)
        // {
        //     user.Roles?.Add(new UserRoleResponseDTO { RoleId = roleId, UserId = user.UserId });
        // }
        
        return user;
    }
    #endregion

}