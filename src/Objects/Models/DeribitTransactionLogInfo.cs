using System.Text.Json;
using System.Text.Json.Serialization;

namespace Deribit.Net.Objects.Models
{
    /// <summary>
    /// Type-dependent additional transaction information.
    /// </summary>
    public class DeribitTransactionLogInfo
    {
        /// <summary>Free-form information when Deribit returns the value as a string, for example [<c>Source: api</c>].</summary>
        [JsonIgnore]
        public string? Text { get; set; }

        /// <summary>Transfer type, for example [<c>subaccount</c>].</summary>
        [JsonPropertyName("transfer_type")]
        public string? TransferType { get; set; }

        /// <summary>Identifier of the user or subaccount on the other side of a transfer.</summary>
        [JsonPropertyName("other_user_id")]
        public long? OtherUserId { get; set; }

        /// <summary>Name of the user or subaccount on the other side of a transfer.</summary>
        [JsonPropertyName("other_user")]
        public string? OtherUser { get; set; }

        /// <summary>Settlement price associated with a settlement entry.</summary>
        [JsonPropertyName("settlement_price")]
        public decimal? SettlementPrice { get; set; }

        /// <summary>Floating profit or loss associated with a settlement entry.</summary>
        [JsonPropertyName("floating_pl")]
        public decimal? FloatingProfitLoss { get; set; }

        /// <summary>Blockchain transaction identifier associated with a deposit or withdrawal.</summary>
        [JsonPropertyName("transaction")]
        public string? TransactionId { get; set; }

        /// <summary>Deposit type, for example [<c>wallet</c>].</summary>
        [JsonPropertyName("deposit_type")]
        public string? DepositType { get; set; }

        /// <summary>Blockchain address associated with a deposit or withdrawal.</summary>
        [JsonPropertyName("addr")]
        public string? Address { get; set; }

        /// <summary>Change in the balance associated with a reward transaction.</summary>
        [JsonPropertyName("balance_change")]
        public decimal? BalanceChange { get; set; }

        /// <summary>Whether commission was paid for the reward transaction.</summary>
        [JsonPropertyName("commission_paid")]
        public bool? CommissionPaid { get; set; }

        /// <summary>Entity associated with the reward transaction.</summary>
        [JsonPropertyName("entity")]
        public string? Entity { get; set; }

        /// <summary>Equity associated with the reward transaction.</summary>
        [JsonPropertyName("equity")]
        public decimal? Equity { get; set; }

        /// <summary>Fee balance associated with the reward transaction.</summary>
        [JsonPropertyName("fee_balance")]
        public decimal? FeeBalance { get; set; }

        /// <summary>Change in fee balance associated with the reward transaction.</summary>
        [JsonPropertyName("fee_balance_change")]
        public decimal? FeeBalanceChange { get; set; }

        /// <summary>Locked balance associated with the reward transaction.</summary>
        [JsonPropertyName("locked_balance")]
        public decimal? LockedBalance { get; set; }

        /// <summary>Native modification timestamp associated with the reward transaction.</summary>
        [JsonPropertyName("m_tstamp")]
        public long? ModificationTimestamp { get; set; }

        /// <summary>Minimum equity associated with the reward transaction.</summary>
        [JsonPropertyName("minimum_equity")]
        public decimal? MinimumEquity { get; set; }

        /// <summary>Native numeric reward-note values associated with the reward transaction.</summary>
        [JsonPropertyName("reward_note")]
        public long[]? RewardNotes { get; set; }

        /// <summary>Sequential user transaction identifier associated with the reward transaction.</summary>
        [JsonPropertyName("user_seq")]
        public long? UserSequence { get; set; }

        /// <summary>Reason of the transaction.</summary>
        [JsonPropertyName("reason")]
        public string? Reason { get; set; }

        /// <summary>Additional type-dependent properties not explicitly modeled by this library.</summary>
        [JsonExtensionData]
        public Dictionary<string, JsonElement>? AdditionalProperties { get; set; }
    }
}
