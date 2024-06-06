namespace svc.App.User.Repositories;

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
                USER_ACCOUNT
            FROM CO_USER
            WHERE USER_ACCOUNT = @UserAccount
        ";
    }
    
}
