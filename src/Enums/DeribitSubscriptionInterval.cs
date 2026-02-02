using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Deribit.Net.Enums
{
    [JsonConverter(typeof(EnumConverter<DeribitSubscriptionInterval>))]
    public enum DeribitSubscriptionInterval
    {
        [Map("agg2")]
        Aggregated,

        [Map("100ms")]
        HundredMs,

        [Map("raw")]
        Raw
    }
}
