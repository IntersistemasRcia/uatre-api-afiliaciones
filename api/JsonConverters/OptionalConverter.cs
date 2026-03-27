using System.Reflection;
using System.Text.Json.Serialization;
using System.Text.Json;
using CleanArchitecture.Application.Models;

namespace CleanArchitecture.API.JsonConverters;

public class OptionalConverter : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
        => typeToConvert.IsGenericType
            && typeToConvert.GetGenericTypeDefinition() == typeof(Optional<>);

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        => (JsonConverter)Activator.CreateInstance(
            type: typeof(OptionalConverterInner<>).MakeGenericType(new Type[] { typeToConvert.GetGenericArguments()[0] }),
            bindingAttr: BindingFlags.Instance | BindingFlags.Public,
            binder: null,
            args: null,
            culture: null
        )!;

    private class OptionalConverterInner<T> : JsonConverter<Optional<T>>
    {
        public override Optional<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => new(JsonSerializer.Deserialize<T>(ref reader, options)!);

        public override void Write(Utf8JsonWriter writer, Optional<T> value, JsonSerializerOptions options)
            => JsonSerializer.Serialize(writer, value.Value, options);
    }
}
