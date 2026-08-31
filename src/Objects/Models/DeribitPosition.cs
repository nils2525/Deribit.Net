using System.Text.Json.Serialization;
using Deribit.Net.Enums;

namespace Deribit.Net.Objects.Models
{
    /// <summary>Deribit account position.</summary>
    public class DeribitPosition
    {
        /// <summary>Instrument name.</summary>
        [JsonPropertyName("instrument_name")]
        public string InstrumentName { get; set; } = string.Empty;

        /// <summary>Instrument kind.</summary>
        [JsonPropertyName("kind")]
        public DeribitSymbolKind Kind { get; set; }

        /// <summary>Account identifier.</summary>
        [JsonPropertyName("user_id")]
        public long UserId { get; set; }

        /// <summary>Average price of the trades that built the position.</summary>
        [JsonPropertyName("average_price")]
        public decimal AveragePrice { get; set; }

        /// <summary>Position direction.</summary>
        [JsonPropertyName("direction")]
        public DeribitPositionDirection Direction { get; set; }

        /// <summary>Current mark price.</summary>
        [JsonPropertyName("mark_price")]
        public decimal MarkPrice { get; set; }

        /// <summary>Position delta.</summary>
        [JsonPropertyName("delta")]
        public decimal Delta { get; set; }

        /// <summary>Current index price.</summary>
        [JsonPropertyName("index_price")]
        public decimal IndexPrice { get; set; }

        /// <summary>Initial margin.</summary>
        [JsonPropertyName("initial_margin")]
        public decimal InitialMargin { get; set; }

        /// <summary>Maintenance margin.</summary>
        [JsonPropertyName("maintenance_margin")]
        public decimal MaintenanceMargin { get; set; }

        /// <summary>Last settlement price.</summary>
        [JsonPropertyName("settlement_price")]
        public decimal SettlementPrice { get; set; }

        /// <summary>Total position profit or loss.</summary>
        [JsonPropertyName("total_profit_loss")]
        public decimal TotalProfitLoss { get; set; }

        /// <summary>Floating profit or loss.</summary>
        [JsonPropertyName("floating_profit_loss")]
        public decimal FloatingProfitLoss { get; set; }

        /// <summary>Realized profit or loss.</summary>
        [JsonPropertyName("realized_profit_loss")]
        public decimal RealizedProfitLoss { get; set; }

        /// <summary>Position size in quote currency for Futures.</summary>
        [JsonPropertyName("size")]
        public decimal Size { get; set; }

        /// <summary>Option gamma, when applicable.</summary>
        [JsonPropertyName("gamma")]
        public decimal? Gamma { get; set; }

        /// <summary>Option vega, when applicable.</summary>
        [JsonPropertyName("vega")]
        public decimal? Vega { get; set; }

        /// <summary>Option theta, when applicable.</summary>
        [JsonPropertyName("theta")]
        public decimal? Theta { get; set; }

        /// <summary>Futures position size in base currency.</summary>
        [JsonPropertyName("size_currency")]
        public decimal? SizeCurrency { get; set; }

        /// <summary>Option average price in USD, when applicable.</summary>
        [JsonPropertyName("average_price_usd")]
        public decimal? AveragePriceUsd { get; set; }

        /// <summary>Option floating profit or loss in USD, when applicable.</summary>
        [JsonPropertyName("floating_profit_loss_usd")]
        public decimal? FloatingProfitLossUsd { get; set; }

        /// <summary>Current available leverage for the Futures position.</summary>
        [JsonPropertyName("leverage")]
        public decimal? Leverage { get; set; }

        /// <summary>Realized funding in the current session.</summary>
        [JsonPropertyName("realized_funding")]
        public decimal? RealizedFunding { get; set; }

        /// <summary>Perpetual interest value.</summary>
        [JsonPropertyName("interest_value")]
        public decimal? InterestValue { get; set; }

        /// <summary>Deprecated estimated liquidation price.</summary>
        [JsonPropertyName("estimated_liquidation_price")]
        public decimal? EstimatedLiquidationPrice { get; set; }

        /// <summary>Margin reserved by open Futures orders.</summary>
        [JsonPropertyName("open_orders_margin")]
        public decimal? OpenOrdersMargin { get; set; }
    }
}
