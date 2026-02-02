using System.Text.Json.Serialization;

namespace Deribit.Net.Objects.Models
{
    internal class DeribitHeartbeat
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = String.Empty;
    }
}
