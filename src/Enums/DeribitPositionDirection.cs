using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Deribit.Net.Enums
{
    /// <summary>Direction of a Deribit position.</summary>
    [JsonConverter(typeof(EnumConverter<DeribitPositionDirection>))]
    public enum DeribitPositionDirection
    {
        /// <summary>No open position.</summary>
        [Map("zero")]
        Zero,

        /// <summary>Long position.</summary>
        [Map("buy")]
        Buy,

        /// <summary>Short position.</summary>
        [Map("sell")]
        Sell,
    }
}
