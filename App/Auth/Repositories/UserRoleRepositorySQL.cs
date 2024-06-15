namespace svc.App.User.Repositories;

/// <summary>
/// 사용자 권한 리포지토리 SQL 클래스
/// </summary>
public class UserRoleRepositorySQL
{
    /// <summary>
    /// 사용자 권한 목록을 조회한다.
    /// </summary>
    public static string ListUserRole()
    {
        return $@"
            SELECT
                UR.USER_ID,
                UR.ROLE_ID
            FROM CO_USER_ROLE UR
            INNER JOIN CO_USER U ON U.USER_ID = UR.USER_ID
            WHERE U.USER_ID = @UserId
        ";
    }

    /// <summary>
    /// 사용자 권한을 추가한다.
    /// </summary>
    public static string AddUserRole()
    {
        return $@"
            INSERT INTO CO_USER_ROLE (USER_ID, ROLE_ID, CREATER_ID)
            VALUES (@UserId, @RoleId, @CreaterId)
        ";
    }
    
}
