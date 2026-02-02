using CryptoExchange.Net.Converters.SystemTextJson;
using Deribit.Net.Enums;
using System.Text.Json.Serialization;

namespace Deribit.Net.Objects.Models
{
    public class DeribitTrade
    {
        /// <summary>
        /// Trade amount. For perpetual and inverse futures the amount is in USD units. For options and linear futures and it is the underlying base currency coi
        /// </summary>
        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("block_trade_id")]
        public string? BlockTradeId { get; set; }

        [JsonPropertyName("block_trade_leg_counter")]
        public int? BlockTradeLegCounter { get; set; }

        [JsonPropertyName("combo_id")]
        public string? ComboId { get; set; }

        [JsonPropertyName("combo_trade_id")]
        public long? ComboTradeId { get; set; }

        /// <summary>
        /// Trade size in contract units (optional, may be absent in historical trades)
        /// </summary>
        [JsonPropertyName("contracts")]
        public decimal Contracts { get; set; }

        [JsonPropertyName("direction")]
        public DeribitTradeSide Side { get; set; }

        [JsonPropertyName("index_price")]
        public decimal IndexPrice { get; set; }

        [JsonPropertyName("instrument_name")]
        public string Symbol { get; set; } = String.Empty;

        [JsonPropertyName("mark_price")]
        public decimal MarkPrice { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("tick_direction")]
        public int TickDirection { get; set; }

        [JsonPropertyName("timestamp")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("trade_id")]
        public string TradeId { get; set; } = String.Empty;

        [JsonPropertyName("trade_seq")]
        public long TradeSequence { get; set; }
    }
}
