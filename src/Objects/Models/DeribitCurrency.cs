using System.Text.Json.Serialization;

namespace Deribit.Net.Objects.Models
{
    public class DeribitCurrency
    {
        [JsonPropertyName("coin_type")]
        public string CoinType { get; set; } = string.Empty;

        [JsonPropertyName("currency")]
        public string Currency { get; set; } = string.Empty;

        [JsonPropertyName("currency_long")]
        public string CurrencyName { get; set; } = string.Empty;

        [JsonPropertyName("fee_precision")]
        public int FeePrecision { get; set; }

        [JsonPropertyName("in_cross_collateral_pool")]
        public bool InCrossCollateralPool { get; set; }

        [JsonPropertyName("min_confirmations")]
        public int MinConfirmations { get; set; }

        [JsonPropertyName("min_withdrawal_fee")]
        public decimal MinWithdrawalFee { get; set; }

        [JsonPropertyName("withdrawal_fee")]
        public decimal WithdrawalFee { get; set; }
    }
}
