using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Deribit.Net.Enums
{
    [JsonConverter(typeof(EnumConverter<DeribitTradeType>))]
    public enum DeribitTradeType
    {
        [Map("limit")]
        Limit,

        [Map("market")]
        Market,

        [Map("liquidation")]
        Liquidation,
    }
}
