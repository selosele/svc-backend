namespace Svc.App.Shared.Converters;

using System.Text.Json;
using System.Text.Json.Serialization;

/// <summary>
/// 빈 문자열을 null로 변환하고, int? 타입을 처리하는 JSON 컨버터
/// </summary>
public class NullableIntConverter : JsonConverter<int?>
{
    #region [메서드]
    /// <summary>
    /// JSON 데이터를 읽어 int? 타입으로 변환한다.
    /// 빈 문자열은 null로 변환된다.
    /// </summary>
    public override int? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null || (reader.TokenType == JsonTokenType.String && string.IsNullOrEmpty(reader.GetString())))
        {
            return null;
        }

        if (reader.TokenType == JsonTokenType.Number && reader.TryGetInt32(out int value))
        {
            return value;
        }

        throw new JsonException("Invalid token type for int?");
    }

    /// <summary>
    /// int? 타입의 값을 JSON으로 쓴다.
    /// 값이 null인 경우 null로 쓴다.
    /// </summary>
    public override void Write(Utf8JsonWriter writer, int? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
        {
            writer.WriteNumberValue(value.Value);
        }
        else
        {
            writer.WriteNullValue();
        }
    }
    #endregion
}