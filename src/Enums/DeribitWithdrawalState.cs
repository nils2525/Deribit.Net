using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Deribit.Net.Enums
{
    [JsonConverter(typeof(EnumConverter<DeribitWithdrawalState>))]
    public enum DeribitWithdrawalState
    {
        [Map("unconfirmed")]
        Unconfirmed,

        [Map("confirmed")]
        Confirmed,

        [Map("cancelled")]
        Cancelled,

        [Map("completed")]
        Completed,

        [Map("interrupted")]
        Interrupted,

        [Map("rejected")]
        Rejected
    }
}
