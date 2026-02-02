using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Deribit.Net.Enums
{
    [JsonConverter(typeof(EnumConverter<DeribitOrderType>))]
    public enum DeribitOrderType
    {
        [Map("all")]
        All,

        [Map("limit")]
        Limit,

        [Map("market")]
        Market,

        [Map("stop_limit")]
        StopLimit,

        [Map("stop_market")]
        StopMarket,
    }
}
