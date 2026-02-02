using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Deribit.Net.Objects.Models
{
    public class DeribitCandle
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("open")]
        public decimal Open { get; set; }

        [JsonPropertyName("high")]
        public decimal High { get; set; }

        [JsonPropertyName("low")]
        public decimal Low { get; set; }

        [JsonPropertyName("close")]
        public decimal Close { get; set; }

        [JsonPropertyName("amount")]
        public decimal QuoteAmount { get; set; }

        [JsonPropertyName("quantity")]
        public decimal BaseAmount { get; set; }

        [JsonPropertyName("tradeCount")]
        public int TradeCount { get; set; }

        [JsonPropertyName("closeTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CloseTime { get; set; }

        [JsonPropertyName("startTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime StartTime { get; set; }

        [JsonPropertyName("ts")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
    }
}
