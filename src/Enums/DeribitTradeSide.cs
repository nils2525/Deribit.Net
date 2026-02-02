using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Deribit.Net.Enums
{
    [JsonConverter(typeof(EnumConverter<DeribitTradeSide>))]
    public enum DeribitTradeSide
    {
        [Map("buy")]
        Buy,

        [Map("sell")]
        Sell
    }
}
