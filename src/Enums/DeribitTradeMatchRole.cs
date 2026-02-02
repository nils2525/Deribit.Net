using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Deribit.Net.Enums
{
    [JsonConverter(typeof(EnumConverter<DeribitTradeMatchRole>))]
    public enum DeribitTradeMatchRole
    {
        [Map("M")]
        Maker,

        [Map("T")]
        Taker
    }
}
