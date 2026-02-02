using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Deribit.Net.Enums
{
    [JsonConverter(typeof(EnumConverter<DeribitOrderKind>))]
    public enum DeribitOrderKind
    {
        [Map("spot")]
        Spot,

        [Map("future")]
        Future,

        [Map("option")]
        Option,

        [Map("future_combo")]
        FutureCombo,

        [Map("option_combo")]
        OptionCombo,
    }
}
