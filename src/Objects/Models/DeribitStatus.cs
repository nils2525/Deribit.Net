using System.Text.Json.Serialization;
using Deribit.Net.Enums;

namespace Deribit.Net.Objects.Models
{
    /// <summary>
    /// Deribit platform lock status.
    /// </summary>
    public class DeribitStatus
    {
        /// <summary>
        /// Whether all currencies are locked (<c>true</c>), some are locked (<c>partial</c>), or none are locked (<c>false</c>).
        /// </summary>
        [JsonPropertyName("locked")]
        public DeribitPlatformLockState Locked { get; set; }

        /// <summary>
        /// Currencies locked platform-wide.
        /// </summary>
        [JsonPropertyName("locked_currencies")]
        public string[] LockedCurrencies { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Currency indices locked platform-wide.
        /// </summary>
        [JsonPropertyName("locked_indices")]
        public string[] LockedIndices { get; set; } = Array.Empty<string>();
    }
}
