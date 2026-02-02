using System.Text.Json.Serialization;

namespace Deribit.Net.Objects.Internal
{
    internal class DeribitResponse<T> : DeribitSocketResponseBase
    {
        [JsonPropertyName("result")]
        public T Data { get; set; }
    }

    internal class DeribitMessage<T> : DeribitSocketResponseBase
    {
        [JsonPropertyName("params")]
        public T Data { get; set; }
    }

    internal abstract class DeribitSocketResponseBase
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("jsonrpc")]
        public string JsonRpc { get; set; } = String.Empty;

        [JsonPropertyName("error")]
        public DeribitResponseError? Error { get; set; }
    }

    internal class DeribitResponseError
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; } = String.Empty;
    }
}
