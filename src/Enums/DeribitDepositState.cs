using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Deribit.Net.Enums
{
    [JsonConverter(typeof(EnumConverter<DeribitDepositState>))]
    public enum DeribitDepositState
    {
        [Map("pending")]
        Pending,

        [Map("completed")]
        Completed,

        [Map("rejected")]
        Rejected,

        [Map("replaced")]
        Replaced,
    }
}
