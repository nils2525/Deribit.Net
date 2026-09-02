using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using Deribit.Net.Objects.Models;

namespace Deribit.Net.Converters
{
    /// <summary>
    /// Converts the object, string and null token shapes returned for transaction log information.
    /// </summary>
    internal sealed class DeribitTransactionLogInfoConverter : JsonConverter<DeribitTransactionLogInfo>
    {
        private static JsonTypeInfo<DeribitTransactionLogInfo> GetTypeInfo(JsonSerializerOptions options)
            => (JsonTypeInfo<DeribitTransactionLogInfo>)options.GetTypeInfo(typeof(DeribitTransactionLogInfo));

        /// <inheritdoc />
        public override DeribitTransactionLogInfo? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
                return null;

            if (reader.TokenType == JsonTokenType.String)
                return new DeribitTransactionLogInfo { Text = reader.GetString() };

            if (reader.TokenType == JsonTokenType.StartObject)
                return JsonSerializer.Deserialize(ref reader, GetTypeInfo(options));

            throw new JsonException($"Unexpected transaction log info token: {reader.TokenType}");
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, DeribitTransactionLogInfo value, JsonSerializerOptions options)
        {
            if (value.Text != null)
            {
                writer.WriteStringValue(value.Text);
                return;
            }

            JsonSerializer.Serialize(writer, value, GetTypeInfo(options));
        }
    }
}
