using System.Text.Json.Serialization;

namespace Deribit.Net.Objects.Models
{
    /// <summary>Consolidated private changes for a Deribit instrument.</summary>
    public class DeribitUserChanges
    {
        /// <summary>Instrument name represented by the notification.</summary>
        [JsonPropertyName("instrument_name")]
        public string InstrumentName { get; set; } = string.Empty;

        /// <summary>Changed orders.</summary>
        [JsonPropertyName("orders")]
        public DeribitUserOrder[] Orders { get; set; } = [];

        /// <summary>New trades.</summary>
        [JsonPropertyName("trades")]
        public DeribitUserTrade[] Trades { get; set; } = [];

        /// <summary>Changed positions.</summary>
        [JsonPropertyName("positions")]
        public DeribitPosition[] Positions { get; set; } = [];
    }
}
