namespace svc.App.User.Repositories;

/// <summary>
/// 사용자 리포지토리 SQL 클래스
/// </summary>
public class UserRepositorySQL
{
    /// <summary>
    /// 사용자를 조회한다.
    /// </summary>
    public static string GetUser()
    {
        return $@"
            SELECT
                USER_ID,
                USER_ACCOUNT,
                USER_PASSWORD
            FROM CO_USER
            WHERE USER_ACCOUNT = @UserAccount
        ";
    }

    /// <summary>
    /// 사용자를 추가한다.
    /// </summary>
    public static string AddUser()
    {
        return $@"
            INSERT INTO CO_USER (USER_ACCOUNT, USER_PASSWORD, CREATER_ID)
            VALUES (@UserAccount, @UserPassword, @CreaterId)
        ";
    }
    
}
