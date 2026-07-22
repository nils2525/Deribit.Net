using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Deribit.Net.Objects.Models
{
    public class DeribitTicker
    {
        [JsonPropertyName("best_ask_amount")]
        public decimal BestAskAmount { get; set; }

        [JsonPropertyName("best_ask_price")]
        public decimal BestAskPrice { get; set; }

        [JsonPropertyName("best_bid_amount")]
        public decimal BestBidAmount { get; set; }

        [JsonPropertyName("best_bid_price")]
        public decimal BestBidPrice { get; set; }

        [JsonPropertyName("current_funding")]
        public decimal? CurrentFunding { get; set; }

        [JsonPropertyName("estimated_delivery_price")]
        public decimal? EstimatedDeliveryPrice { get; set; }

        [JsonPropertyName("funding_8h")]
        public decimal? Funding8H { get; set; }

        [JsonPropertyName("index_price")]
        public decimal IndexPrice { get; set; }

        [JsonPropertyName("instrument_name")]
        public string Symbol { get; set; } = String.Empty;

        [JsonPropertyName("interest_rate")]
        public decimal? InterestRate { get; set; }

        [JsonPropertyName("interest_value")]
        public decimal? InterestValue { get; set; }

        /// <summary>
        /// ["<c>last_price</c>"] The last trade price, or <see langword="null"/> when no trade price is available
        /// </summary>
        [JsonPropertyName("last_price")]
        public decimal? LastPrice { get; set; }

        [JsonPropertyName("mark_price")]
        public decimal MarkPrice { get; set; }

        [JsonPropertyName("max_price")]
        public decimal MaxPrice { get; set; }

        [JsonPropertyName("min_price")]
        public decimal MinPrice { get; set; }

        [JsonPropertyName("open_interest")]
        public decimal OpenInterest { get; set; }

        [JsonPropertyName("settlement_price")]
        public decimal? SettlementPrice { get; set; }

        /// <summary>
        /// open, closed
        /// </summary>
        [JsonPropertyName("state")]
        public string State { get; set; } = String.Empty;

        [JsonPropertyName("stats")]
        public DeribitTickerStats Stats { get; set; } = new DeribitTickerStats();

        [JsonPropertyName("timestamp")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("underlying_index")]
        public decimal? UnderlyingIndex { get; set; }

        [JsonPropertyName("underlying_price")]
        public decimal? UnderlyingPrice { get; set; }
    }

    public class DeribitTickerStats
    {
        [JsonPropertyName("high")]
        public decimal? High { get; set; }

        [JsonPropertyName("low")]
        public decimal? Low { get; set; }

        [JsonPropertyName("volume")]
        public decimal Volume { get; set; }

        [JsonPropertyName("volume_usd")]
        public decimal? VolumeUsd { get; set; }

        [JsonPropertyName("price_change")]
        public decimal? PriceChange { get; set; }
    }
}
