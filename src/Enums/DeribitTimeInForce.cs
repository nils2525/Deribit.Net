using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Deribit.Net.Enums
{
    /// <summary>Specifies how long a Deribit order remains active.</summary>
    [JsonConverter(typeof(EnumConverter<DeribitTimeInForce>))]
    public enum DeribitTimeInForce
    {
        /// <summary>The order remains active until it is filled or cancelled.</summary>
        [Map("good_til_cancelled")]
        GoodTillCancelled,

        /// <summary>The order remains active until the end of the trading day.</summary>
        [Map("good_til_day")]
        GoodTillDay,

        /// <summary>The order must fill completely and immediately or be cancelled.</summary>
        [Map("fill_or_kill")]
        FillOrKill,

        /// <summary>The immediately executable part is filled and the remainder is cancelled.</summary>
        [Map("immediate_or_cancel")]
        ImmediateOrCancel,
    }
}
