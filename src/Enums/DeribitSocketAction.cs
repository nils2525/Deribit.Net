using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Deribit.Net.Enums
{
    [JsonConverter(typeof(EnumConverter<DeribitSocketAction>))]
    public enum DeribitSocketAction
    {
        [Map("update", "change")]
        Update,

        [Map("snapshot")]
        Snapshot,
    }
}
