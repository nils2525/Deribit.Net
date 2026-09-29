using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using Deribit.Net.Enums;

namespace Deribit.Net.Objects.Models
{
    public class DeribitUserTrade
    {
        [JsonPropertyName("trade_id")]
        public string TradeId { get; set; } = string.Empty;

        /// <summary>
        /// Direction of the "tick" (0 = Plus Tick, 1 = Zero-Plus Tick, 2 = Minus Tick, 3 = Zero-Minus Tick).
        /// </summary>
        [JsonPropertyName("tick_direction")]
        public int TickDirection { get; set; }

        [JsonPropertyName("fee_currency")]
        public string FeeCurrency { get; set; } = string.Empty;

        [JsonPropertyName("api")]
        public bool Api { get; set; }

        /// <summary>
        /// Advanced type of user order: "usd" or "implv" (only for options; omitted if not applicable)
        /// </summary>
        [JsonPropertyName("advanced")]
        public string? Advanced { get; set; }

        [JsonPropertyName("order_id")]
        public string OrderId { get; set; } = string.Empty;

        /// <summary>
        /// Describes what was role of users order: "M" when it was maker order, "T" when it was taker order
        /// </summary>
        [JsonPropertyName("liquidity")]
        public DeribitTradeMatchRole MatchRole { get; set; }

        [JsonPropertyName("post_only")]
        public bool PostOnly { get; set; }

        [JsonPropertyName("direction")]
        public DeribitTradeSide Direction { get; set; }

        [JsonPropertyName("contracts")]
        public decimal? Contracts { get; set; }

        [JsonPropertyName("mmp")]
        public bool Mmp { get; set; }

        [JsonPropertyName("fee")]
        public decimal Fee { get; set; }

        [JsonPropertyName("quote_id")]
        public string? QuoteId { get; set; }

        [JsonPropertyName("index_price")]
        public decimal IndexPrice { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; } = string.Empty;

        [JsonPropertyName("block_trade_id")]
        public string? BlockTradeId { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("combo_id")]
        public string? ComboId { get; set; }

        [JsonPropertyName("order_type")]
        public DeribitTradeType TradeType { get; set; }

        [JsonPropertyName("profit_loss")]
        public decimal? ProfitLoss { get; set; }

        [JsonPropertyName("timestamp")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Option implied volatility for the price (Option only)
        /// </summary>
        [JsonPropertyName("iv")]
        public decimal? Iv { get; set; }

        [JsonPropertyName("state")]
        public DeribitOrderState OrderState { get; set; }

        /// <summary>
        /// Underlying price for implied volatility calculations (Options only)
        /// </summary>
        [JsonPropertyName("underlying_price")]
        public decimal? UnderlyingPrice { get; set; }

        [JsonPropertyName("quote_set_id")]
        public string? QuoteSetId { get; set; }

        /// <summary>
        /// Mark Price at the moment of trade
        /// </summary>
        [JsonPropertyName("mark_price")]
        public decimal MarkPrice { get; set; }

        [JsonPropertyName("combo_trade_id")]
        public string? ComboTradeId { get; set; }

        [JsonPropertyName("reduce_only")]
        public bool ReduceOnly { get; set; }

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("trade_seq")]
        public long TradeSeq { get; set; }

        [JsonPropertyName("risk_reducing")]
        public bool RiskReducing { get; set; }

        [JsonPropertyName("instrument_name")]
        public string InstrumentName { get; set; } = string.Empty;

        /// <summary>Legacy matching identifier; the API documents this field as always [<c>null</c>].</summary>
        [JsonPropertyName("matching_id")]
        public string? MatchingId { get; set; }

        /// <summary>Starbase trade timestamp in nanoseconds since the Unix epoch, when available.</summary>
        [JsonPropertyName("starbase_timestamp")]
        public long? StarbaseTimestamp { get; set; }

        /// <summary>Raw Starbase order ID for this user's order, when available.</summary>
        [JsonPropertyName("starbase_order_id")]
        public long? StarbaseOrderId { get; set; }

        /// <summary>Client ID for an order submitted directly to Starbase; absent for Deribit API orders.</summary>
        [JsonPropertyName("starbase_client_order_id")]
        public string? StarbaseClientOrderId { get; set; }

        /// <summary>Original API order type, such as [<c>market</c>] or [<c>market_limit</c>], when represented internally as a limit order.</summary>
        [JsonPropertyName("original_order_type")]
        public string? OriginalOrderType { get; set; }

        /// <summary>Liquidated sides: [<c>M</c>] for maker, [<c>T</c>] for taker, or [<c>MT</c>] for both; absent otherwise.</summary>
        [JsonPropertyName("liquidation")]
        public string? Liquidation { get; set; }

        /// <summary>Number of legs when the trade belongs to a block trade.</summary>
        [JsonPropertyName("block_trade_leg_count")]
        public int? BlockTradeLegCount { get; set; }

        /// <summary>Block RFQ identifier, when applicable.</summary>
        [JsonPropertyName("block_rfq_id")]
        public long? BlockRfqId { get; set; }

        /// <summary>Block RFQ quote identifier, when applicable.</summary>
        [JsonPropertyName("block_rfq_quote_id")]
        public long? BlockRfqQuoteId { get; set; }

        /// <summary>Leg trades returned for a combo trade, when applicable.</summary>
        [JsonPropertyName("legs")]
        public DeribitUserTrade[]? Legs { get; set; }

        /// <summary>Starbase match identifier, when available.</summary>
        [JsonPropertyName("starbase_match_id")]
        public long? StarbaseMatchId { get; set; }
    }
}
