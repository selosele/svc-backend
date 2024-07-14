namespace svc.App.Shared.Utils;

/// <summary>
/// 암호화 유틸 클래스
/// </summary>
public class EncryptUtil
{
    #region Methods
    /// <summary>
    /// 입력 문자열을 암호화해서 반환한다.
    /// </summary>
    public static string Encrypt(string input)
        => BCrypt.Net.BCrypt.HashPassword(input);

    /// <summary>
    /// 입력 문자열과 암호화된 문자열이 동일한지 확인한다.
    /// </summary>
    public static bool Verify(string input, string hashedInput)
        => BCrypt.Net.BCrypt.Verify(input, hashedInput);
    #endregion

}
