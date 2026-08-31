using System.Text.Json.Serialization;

using Deribit.Net.Enums;

namespace Deribit.Net.Objects.Models
{
    public class DeribitAccount
    {
        [JsonPropertyName("id")]
        public long AccountId { get; set; }

        [JsonPropertyName("email")]
        public string Mail { get; set; }

        [JsonPropertyName("login_enabled")]
        public bool LoginEnabled { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("summaries")]
        public List<DeribitAccountBalance> Balances { get; set; } = new();
    }

    public class DeribitAccountBalance
    {
        [JsonPropertyName("currency")]
        public string Currency { get; set; } = string.Empty;

        [JsonPropertyName("balance")]
        public decimal Balance { get; set; }

        /// <summary>
        /// The account's balance reserved in active spot orders
        /// </summary>
        [JsonPropertyName("spot_reserve")]
        public decimal SpotReserved { get; set; }

        /// <summary>
        /// The account's balance reserved in other orders
        /// </summary>
        [JsonPropertyName("additional_reserve")]
        public decimal AdditionalReserved { get; set; }

        /// <summary>
        /// The account's available funds. When cross collateral is enabled, this aggregated value is calculated by converting the sum of each cross collateral currency's value to the given currency, using each cross collateral currency's index.
        /// </summary>
        [JsonPropertyName("available_funds")]
        public decimal AvailableFunds { get; set; }

        [JsonPropertyName("equity")]
        public decimal Equity { get; set; }

        /// <summary>The margin model enabled for the account.</summary>
        [JsonPropertyName("margin_model")]
        public DeribitMarginModel MarginModel { get; set; }
    }
}
