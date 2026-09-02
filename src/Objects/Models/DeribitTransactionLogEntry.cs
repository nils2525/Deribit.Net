using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using Deribit.Net.Converters;

namespace Deribit.Net.Objects.Models
{
    /// <summary>
    /// A transaction log entry.
    /// </summary>
    public class DeribitTransactionLogEntry
    {
        /// <summary>Unique transaction log identifier.</summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>Currency code.</summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; } = string.Empty;

        /// <summary>Transaction timestamp.</summary>
        [JsonPropertyName("timestamp")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }

        /// <summary>User identifier.</summary>
        [JsonPropertyName("user_id")]
        public long UserId { get; set; }

        /// <summary>Commission paid in the base currency. A negative value represents a rebate.</summary>
        [JsonPropertyName("commission")]
        public decimal? Commission { get; set; }

        /// <summary>Realized session profit or loss for futures and perpetual contracts, or the option premium paid or received.</summary>
        [JsonPropertyName("cashflow")]
        public decimal Cashflow { get; set; }

        /// <summary>Cash balance after the transaction.</summary>
        [JsonPropertyName("balance")]
        public decimal Balance { get; set; }

        /// <summary>Change in cash balance caused by the transaction.</summary>
        [JsonPropertyName("change")]
        public decimal Change { get; set; }

        /// <summary>Sequential user transaction identifier.</summary>
        [JsonPropertyName("user_seq")]
        public long UserSequence { get; set; }

        /// <summary>Native transaction category. Common values include [<c>trade</c>], [<c>settlement</c>] and [<c>delivery</c>].</summary>
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        /// <summary>System name or user-defined subaccount alias.</summary>
        [JsonPropertyName("username")]
        public string Username { get; set; } = string.Empty;

        /// <summary>Position-transfer role, when applicable. Values are [<c>source</c>] or [<c>destination</c>].</summary>
        [JsonPropertyName("role")]
        public string? Role { get; set; }

        /// <summary>Type-dependent additional information. Deribit returns object, string and null token shapes.</summary>
        [JsonPropertyName("info")]
        [JsonConverter(typeof(DeribitTransactionLogInfoConverter))]
        public DeribitTransactionLogInfo? Info { get; set; }

        /// <summary>Updated equity value after the transaction.</summary>
        [JsonPropertyName("equity")]
        public decimal Equity { get; set; }

        /// <summary>Mark price during the trade, when applicable.</summary>
        [JsonPropertyName("mark_price")]
        public decimal? MarkPrice { get; set; }

        /// <summary>Settlement price for the instrument during delivery, when applicable.</summary>
        [JsonPropertyName("settlement_price")]
        public decimal? SettlementPrice { get; set; }

        /// <summary>Index price for the instrument during delivery, when applicable.</summary>
        [JsonPropertyName("index_price")]
        public decimal? IndexPrice { get; set; }

        /// <summary>Instrument name, when applicable.</summary>
        [JsonPropertyName("instrument_name")]
        public string? InstrumentName { get; set; }

        /// <summary>Updated position size after the transaction, when applicable.</summary>
        [JsonPropertyName("position")]
        public decimal? Position { get; set; }

        /// <summary>Native transaction side or position direction.</summary>
        [JsonPropertyName("side")]
        public string Side { get; set; } = string.Empty;

        /// <summary>Requested order size, when applicable.</summary>
        [JsonPropertyName("amount")]
        public decimal? Amount { get; set; }

        /// <summary>Trade, settlement or delivery price, when applicable.</summary>
        [JsonPropertyName("price")]
        public decimal? Price { get; set; }

        /// <summary>Currency associated with <see cref="Price"/>, when applicable.</summary>
        [JsonPropertyName("price_currency")]
        public string? PriceCurrency { get; set; }

        /// <summary>Trade identifier, unique per currency, when applicable.</summary>
        [JsonPropertyName("trade_id")]
        public string? TradeId { get; set; }

        /// <summary>Order identifier, when applicable.</summary>
        [JsonPropertyName("order_id")]
        public string? OrderId { get; set; }

        /// <summary>Trade role of the user. Values are [<c>maker</c>] or [<c>taker</c>].</summary>
        [JsonPropertyName("user_role")]
        public string? UserRole { get; set; }

        /// <summary>Fee role of the user. Values are [<c>maker</c>] or [<c>taker</c>].</summary>
        [JsonPropertyName("fee_role")]
        public string? FeeRole { get; set; }

        /// <summary>Whether the cashflow is immediately settled rather than awaiting settlement.</summary>
        [JsonPropertyName("profit_as_cashflow")]
        public bool? ProfitAsCashflow { get; set; }

        /// <summary>Funding profit or loss accrued since the previous trade or position change.</summary>
        [JsonPropertyName("interest_pl")]
        public decimal? InterestProfitLoss { get; set; }

        /// <summary>Block RFQ identifier, when the trade was part of a block RFQ.</summary>
        [JsonPropertyName("block_rfq_id")]
        public long? BlockRfqId { get; set; }

        /// <summary>IP address from which the trade was initiated, when available.</summary>
        [JsonPropertyName("ip")]
        public string? IpAddress { get; set; }

        /// <summary>Starbase match identifier, when applicable.</summary>
        [JsonPropertyName("starbase_match_id")]
        public long? StarbaseMatchId { get; set; }

        /// <summary>Raw Starbase order identifier, when applicable.</summary>
        [JsonPropertyName("starbase_order_id")]
        public long? StarbaseOrderId { get; set; }

        /// <summary>Starbase causal timestamp in nanoseconds, when applicable.</summary>
        [JsonPropertyName("starbase_timestamp")]
        public long? StarbaseTimestamp { get; set; }

        /// <summary>Realized profit or loss accrued in the current trading session.</summary>
        [JsonPropertyName("session_rpl")]
        public decimal? SessionRealizedProfitLoss { get; set; }

        /// <summary>Unrealized profit or loss on open positions in the current trading session.</summary>
        [JsonPropertyName("session_upl")]
        public decimal? SessionUnrealizedProfitLoss { get; set; }

        /// <summary>Total funding profit or loss accrued in the current trading session.</summary>
        [JsonPropertyName("total_interest_pl")]
        public decimal? TotalInterestProfitLoss { get; set; }

        /// <summary>Order size in contract units, when available.</summary>
        [JsonPropertyName("contracts")]
        public decimal? Contracts { get; set; }
    }
}
