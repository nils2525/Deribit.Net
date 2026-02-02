using System.Text.Json.Serialization;

namespace Deribit.Net.Objects.Models
{
    public class DeribitStatus
    {
        /// <summary>
        /// true, false, partial
        /// </summary>
        [JsonPropertyName("locked")]
        public string Locked { get; set; } = String.Empty;

        [JsonPropertyName("locked_indices")]
        public string[] LockedIndices { get; set; } = Array.Empty<string>();
    }
}
