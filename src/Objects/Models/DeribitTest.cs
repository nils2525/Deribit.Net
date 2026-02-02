using System.Text.Json.Serialization;

namespace Deribit.Net.Objects.Models
{
    internal class DeribitTest
    {
        [JsonPropertyName("version")]
        public string Version { get; set; } = string.Empty;
    }
}
