using CryptoExchange.Net.Converters.SystemTextJson;
using Deribit.Net.Enums;
using System.Text.Json.Serialization;

namespace Deribit.Net.Objects.Models
{
    public class DeribitSymbol
    {
        [JsonPropertyName("base_currency")]
        public string BaseCurrency { get; set; } = string.Empty;

        [JsonPropertyName("block_trade_commission")]
        public decimal BlockTradeCommission { get; set; }

        [JsonPropertyName("block_trade_min_trade_amount")]
        public decimal BlockTradeMinTradeAmount { get; set; }

        [JsonPropertyName("block_trade_tick_size")]
        public decimal BlockTradeTickSize { get; set; }

        [JsonPropertyName("contract_size")]
        public decimal? ContractSize { get; set; }

        [JsonPropertyName("counter_currency")]
        public string CounterCurrency { get; set; } = string.Empty;

        [JsonPropertyName("creation_timestamp")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreationTimestamp { get; set; }

        [JsonPropertyName("expiration_timestamp")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime ExpirationTimestamp { get; set; }

        [JsonPropertyName("instrument_id")]
        public int SymbolId { get; set; }

        [JsonPropertyName("instrument_name")]
        public string Symbol { get; set; } = string.Empty;

        [JsonPropertyName("instrument_type")]
        public string SymbolType { get; set; } = string.Empty;

        [JsonPropertyName("is_active")]
        public bool IsActive { get; set; }

        [JsonPropertyName("kind")]
        public DeribitSymbolKind Kind { get; set; }

        [JsonPropertyName("maker_commission")]
        public decimal MakerCommission { get; set; }

        [JsonPropertyName("max_leverage")]
        public int? MaxLeverage { get; set; }

        [JsonPropertyName("max_liquidation_commission")]
        public decimal? MaxLiquidationCommission { get; set; }

        [JsonPropertyName("min_trade_amount")]
        public decimal MinTradeAmount { get; set; }

        [JsonPropertyName("option_type")]
        public string OptionType { get; set; } = string.Empty;

        [JsonPropertyName("price_index")]
        public string PriceIndex { get; set; } = string.Empty;

        [JsonPropertyName("quote_currency")]
        public string QuoteCurrency { get; set; } = string.Empty;

        [JsonPropertyName("rfq")]
        public bool Rfq { get; set; }

        [JsonPropertyName("settlement_currency")]
        public string SettlementCurrency { get; set; } = string.Empty;

        [JsonPropertyName("strike")]
        public decimal? Strike { get; set; }

        [JsonPropertyName("taker_commission")]
        public decimal TakerCommission { get; set; }

        [JsonPropertyName("tick_size")]
        public decimal TickSize { get; set; }

        [JsonPropertyName("tick_size_steps")]
        public List<DeribitSymbolTickSizeStep> TickSizeSteps { get; set; } = new List<DeribitSymbolTickSizeStep>();
    }

    public class DeribitSymbolTickSizeStep
    {
        [JsonPropertyName("above_price")]
        public decimal AbovePrice { get; set; }

        [JsonPropertyName("tick_size")]
        public decimal TickSize { get; set; }
    }
}