using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Deribit.Net.Objects.Models
{
    public class DeribitTimestamp
    {
        [JsonPropertyName("result")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
    }
}
