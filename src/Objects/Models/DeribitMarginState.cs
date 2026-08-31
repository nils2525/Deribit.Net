using System.Text.Json.Serialization;

namespace Deribit.Net.Objects.Models
{
    /// <summary>Portfolio state before or after a margin-model change.</summary>
    public class DeribitMarginState
    {
        /// <summary>Maintenance-margin rate.</summary>
        [JsonPropertyName("maintenance_margin_rate")]
        public decimal MaintenanceMarginRate { get; set; }

        /// <summary>Initial-margin rate.</summary>
        [JsonPropertyName("initial_margin_rate")]
        public decimal InitialMarginRate { get; set; }

        /// <summary>Available balance.</summary>
        [JsonPropertyName("available_balance")]
        public decimal AvailableBalance { get; set; }
    }
}
