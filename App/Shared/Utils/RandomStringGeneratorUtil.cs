using System.Text;
using System.Security.Cryptography;

namespace Svc.App.Shared.Utils;

/// <summary>
/// 랜덤 문자열 생성 유틸
/// </summary>
public class RandomStringGeneratorUtil
{
    #region [필드]
    /// <summary>
    /// 랜덤 문자열 생성에 사용할 문자열 (영문 대문자 및 숫자)
    /// </summary>
    private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    #endregion

    #region [메서드]
    /// <summary>
    /// 지정된 길이만큼 랜덤 문자열을 생성해서 반환한다.
    /// </summary>
    public static string Generate(int length)
    {
        if (length <= 0) throw new ArgumentException("0 이상의 숫자가 입력되어야 해요.");

        var result = new StringBuilder(length);     // 생성할 문자열을 저장할 StringBuilder 초기화
        var rng = RandomNumberGenerator.Create();   // 암호학적으로 안전한 난수 생성기를 사용하여 난수 생성
        byte[] uintBuffer = new byte[sizeof(uint)]; // 4바이트 크기의 배열을 생성 (uint형 값을 저장하기 위함)

        while (length-- > 0)
        {
            // 난수 생성기를 사용하여 난수를 uintBuffer에 채움
            rng.GetBytes(uintBuffer);

            // uintBuffer에서 32비트 부호 없는 정수로 변환
            uint num = BitConverter.ToUInt32(uintBuffer, 0);

            // _chars 배열의 길이로 나눈 나머지를 인덱스로 사용하여 랜덤 문자 선택
            result.Append(_chars[(int)(num % (uint)_chars.Length)]);
        }
        return result.ToString();
    }
    #endregion

}
