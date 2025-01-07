using System.Text.Json;
using System.Text.Json.Serialization;

/// <summary>
/// 빈 문자열을 null로 변환하고, double? 타입을 처리하는 JSON 컨버터 클래스
/// </summary>
public class NullableDoubleConverter : JsonConverter<double?>
{
    /// <summary>
    /// JSON 데이터를 읽어 double? 타입으로 변환한다.
    /// 빈 문자열은 null로 변환된다.
    /// </summary>
    public override double? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String && string.IsNullOrEmpty(reader.GetString()))
        {
            return null;
        }
        return reader.GetDouble();
    }

    /// <summary>
    /// double? 타입의 값을 JSON으로 쓴다.
    /// 값이 null인 경우 null로 쓴다.
    /// </summary>
    public override void Write(Utf8JsonWriter writer, double? value, JsonSerializerOptions options)
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
}