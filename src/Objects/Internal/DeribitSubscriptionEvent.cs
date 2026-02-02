using System.Text.Json.Serialization;

namespace Deribit.Net.Objects.Internal
{
    internal class DeribitSubscriptionEvent<T>
    {
        [JsonPropertyName("channel")]
        public string Channel { get; set; } = string.Empty;

        [JsonPropertyName("data")]
        public T Data { get; set; } = default!;
    }
}
