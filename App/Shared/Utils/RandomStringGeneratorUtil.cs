using System.Text;
using System.Security.Cryptography;

namespace Svc.App.Shared.Utils;

/// <summary>
/// 랜덤 문자열 생성 유틸 클래스
/// </summary>
public class RandomStringGeneratorUtil
{
    #region Fields
    /// <summary>
    /// 랜덤 문자열 생성에 사용할 문자열
    /// </summary>
    private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    #endregion

    #region Methods
    /// <summary>
    /// 랜덤 문자열을 생성해서 반환한다.
    /// </summary>
    public static string Generate(int length)
    {
        if (length <= 0) throw new ArgumentException("0 이상의 숫자가 입력되어야 합니다.");

        var result = new StringBuilder(length);
        var rng = RandomNumberGenerator.Create();
        byte[] uintBuffer = new byte[sizeof(uint)];

        while (length-- > 0)
        {
            rng.GetBytes(uintBuffer);
            uint num = BitConverter.ToUInt32(uintBuffer, 0);
            result.Append(_chars[(int)(num % (uint)_chars.Length)]);
        }
        return result.ToString();
    }
    #endregion

}
