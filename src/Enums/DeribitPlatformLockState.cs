using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Deribit.Net.Enums
{
    /// <summary>
    /// Deribit platform-wide currency and index lock state.
    /// </summary>
    [JsonConverter(typeof(EnumConverter<DeribitPlatformLockState>))]
    public enum DeribitPlatformLockState
    {
        /// <summary>
        /// No currencies or indices are locked.
        /// </summary>
        [Map("false")]
        Unlocked,

        /// <summary>
        /// Only the currencies or indices listed in the status response are locked.
        /// </summary>
        [Map("partial")]
        PartiallyLocked,

        /// <summary>
        /// All currencies are locked.
        /// </summary>
        [Map("true")]
        Locked
    }
}
