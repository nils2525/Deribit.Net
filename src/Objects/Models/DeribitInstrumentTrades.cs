using System.Text.Json.Serialization;

namespace Deribit.Net.Objects.Models
{
    public class DeribitInstrumentTrades
    {
        [JsonPropertyName("trades")]
        public DeribitUserTrade[] Trades { get; set; } = Array.Empty<DeribitUserTrade>();
    }
}
