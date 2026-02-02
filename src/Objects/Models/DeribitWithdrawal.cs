using System.Text.Json.Serialization;
using Deribit.Net.Enums;

namespace Deribit.Net.Objects.Models
{
    public class DeribitWithdrawal
    {
        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("confirmed_timestamp")]
        public DateTime? ConfirmedTimestamp { get; set; }

        [JsonPropertyName("created_timestamp")]
        public DateTime CreatedTimestamp { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; } = string.Empty;

        [JsonPropertyName("fee")]
        public decimal Fee { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("priority")]
        public decimal Priority { get; set; }

        [JsonPropertyName("state")]
        public DeribitWithdrawalState State { get; set; }

        [JsonPropertyName("transaction_id")]
        public string? TransactionId { get; set; }

        [JsonPropertyName("updated_timestamp")]
        public DateTime UpdatedTimestamp { get; set; }
    }
}
