using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using System.Text.Json.Serialization;

namespace Deribit.Net.Objects.Internal
{
    internal class DeribitSocketRequest
    {
        [JsonPropertyName("jsonrpc")]
        public string JsonRpc { get; init; } = "2.0";

        [JsonPropertyName("id")]
        public int Id { get; } = ExchangeHelpers.NextId();

        [JsonPropertyName("method")]
        public string Method { get; } = String.Empty;

        [JsonPropertyName("params"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Parameters? Parameters { get; init; }

        [JsonPropertyName("access_token"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? AccessToken { get; init; }

        public DeribitSocketRequest(string method, Parameters? parameters = null, string? accessToken = null)
        {
            Method = method;
            Parameters = parameters;
            AccessToken = accessToken;
        }
    }
}
