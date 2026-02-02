using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using Deribit.Net.Enums;

namespace Deribit.Net.Objects.Models
{
    public class DeribitUserOrder
    {
        [JsonPropertyName("quote")]
        public bool IsQuote { get; set; }

        [JsonPropertyName("triggered")]
        public bool IsTriggered { get; set; }

        [JsonPropertyName("mobile")]
        public bool IsMobile { get; set; }

        [JsonPropertyName("app_name")]
        public string AppName { get; set; } = string.Empty;

        /// <summary>
        /// Implied volatility in percent. (Only if advanced="implv")
        /// </summary>
        [JsonPropertyName("implv")]
        public decimal? ImpliedVolatility { get; set; }

        /// <summary>
        /// Option price in USD (Only if advanced="usd")
        /// </summary>
        [JsonPropertyName("usd")]
        public decimal? OptionPriceUsd { get; set; }

        [JsonPropertyName("oto_order_ids")]
        public List<string> OtoOrderIds { get; set; } = new List<string>();

        [JsonPropertyName("api")]
        public bool IsApi { get; set; }

        [JsonPropertyName("average_price")]
        public decimal? AveragePrice { get; set; }

        /// <summary>
        /// advanced type: "usd" or "implv" (Only for options; field is omitted if not applicable).
        /// </summary>
        [JsonPropertyName("advanced")]
        public string? Advanced { get; set; }

        [JsonPropertyName("order_id")]
        public string OrderId { get; set; } = string.Empty;

        [JsonPropertyName("post_only")]
        public bool IsPostOnly { get; set; }

        [JsonPropertyName("filled_amount")]
        public decimal FilledAmount { get; set; }

        /// <summary>
        /// Trigger type (only for trigger orders). Allowed values: "index_price", "mark_price", "last_price".
        /// </summary>
        [JsonPropertyName("trigger")]
        public string? TriggerType { get; set; }

        [JsonPropertyName("direction")]
        public DeribitTradeSide Side { get; set; }

        [JsonPropertyName("contracts")]
        public decimal? Contracts { get; set; }

        /// <summary>
        /// true if the order is an order that can be triggered by another order, otherwise not present.
        /// </summary>
        [JsonPropertyName("is_secondary_oto")]
        public bool IsSecondaryOto { get; set; }

        /// <summary>
        /// true if the order was edited (by user or - in case of advanced options orders - by pricing engine), otherwise false.
        /// </summary>
        [JsonPropertyName("replaced")]
        public bool IsReplaced { get; set; }

        [JsonPropertyName("mmp_group")]
        public string? MmpGroup { get; set; }

        [JsonPropertyName("mmp")]
        public bool IsMmp { get; set; }

        [JsonPropertyName("last_update_timestamp")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime LastUpdateTimestamp { get; set; }

        [JsonPropertyName("creation_timestamp")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreationTimestamp { get; set; }

        [JsonPropertyName("cancel_reason")]
        public DeribitOrderCancelReason? CancelReason { get; set; }

        [JsonPropertyName("mmp_cancelled")]
        public bool? IsMmpCancelled { get; set; }

        [JsonPropertyName("quote_id")]
        public string? QuoteId { get; set; }

        [JsonPropertyName("order_state")]
        public DeribitOrderState OrderState { get; set; }

        [JsonPropertyName("is_rebalance")]
        public bool IsRebalance { get; set; }

        /// <summary>
        /// true if order has reject_post_only flag (field is present only when post_only is true)
        /// </summary>
        [JsonPropertyName("reject_post_only")]
        public bool? IsRejectPostOnly { get; set; }

        /// <summary>
        /// User defined label (up to 64 characters)
        /// </summary>
        [JsonPropertyName("label")]
        public string? Label { get; set; }

        /// <summary>
        /// Optional (not added for spot). true if order was automatically created during liquidation
        /// </summary>
        [JsonPropertyName("is_liquidation")]
        public bool? IsLiquidation { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("web")]
        public bool? IsWeb { get; set; }

        /// <summary>
        /// Order time in force: "good_til_cancelled", "good_til_day", "fill_or_kill" or "immediate_or_cancel"
        /// </summary>
        [JsonPropertyName("time_in_force")]
        public string TimeInForce { get; set; } = string.Empty;

        [JsonPropertyName("trigger_reference_price")]
        public decimal? TriggerReferencePrice { get; set; }

        [JsonPropertyName("order_type")]
        public DeribitOrderType OrderType { get; set; }

        [JsonPropertyName("is_primary_otoco")]
        public bool? IsPrimaryOtoco { get; set; }

        [JsonPropertyName("original_order_type")]
        public DeribitOrderType? OriginalOrderType { get; set; }

        [JsonPropertyName("block_trade")]
        public bool IsBlockTrade { get; set; }

        [JsonPropertyName("trigger_price")]
        public decimal? TriggerPrice { get; set; }

        [JsonPropertyName("oco_ref")]
        public string? OcoRef { get; set; }

        [JsonPropertyName("trigger_offset")]
        public decimal? TriggerOffset { get; set; }

        [JsonPropertyName("quote_set_id")]
        public string? QuoteSetId { get; set; }

        [JsonPropertyName("auto_replaced")]
        public bool IsAutoReplaced { get; set; }

        [JsonPropertyName("reduce_only")]
        public bool? IsReduceOnly { get; set; }

        [JsonPropertyName("max_show")]
        public decimal MaxShow { get; set; }

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("risk_reducing")]
        public bool IsRiskReducing { get; set; }

        [JsonPropertyName("instrument_name")]
        public string InstrumentName { get; set; } = string.Empty;

        [JsonPropertyName("trigger_fill_condition")]
        public string TriggerFillCondition { get; set; } = string.Empty;

        [JsonPropertyName("primary_order_id")]
        public string? PrimaryOrderId { get; set; }
    }
}
