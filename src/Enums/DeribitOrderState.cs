using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Deribit.Net.Enums
{
    [JsonConverter(typeof(EnumConverter<DeribitOrderState>))]
    public enum DeribitOrderState
    {
        [Map("open")]
        Open,

        [Map("filled")]
        Filled,

        [Map("rejected")]
        Rejected,

        [Map("cancelled")]
        Cancelled,

        [Map("untriggered")]
        Untriggered,

        [Map("archive")]
        Archive
    }
}
