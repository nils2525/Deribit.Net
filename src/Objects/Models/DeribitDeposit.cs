using System.Text.Json.Serialization;
using Deribit.Net.Enums;

namespace Deribit.Net.Objects.Models
{
    public class DeribitDeposit
    {
        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; } = string.Empty;

        [JsonPropertyName("received_timestamp")]
        public DateTime ReceivedTimestamp { get; set; }

        [JsonPropertyName("state")]
        public DeribitDepositState State { get; set; }

        [JsonPropertyName("transaction_id")]
        public string TransactionId { get; set; } = string.Empty;

        [JsonPropertyName("updated_timestamp")]
        public DateTime UpdatedTimestamp { get; set; }
    }
}
