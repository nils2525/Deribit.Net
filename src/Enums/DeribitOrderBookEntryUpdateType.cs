using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Deribit.Net.Enums
{
    [JsonConverter(typeof(EnumConverter<DeribitOrderBookEntryUpdateType>))]
    public enum DeribitOrderBookEntryUpdateType
    {
        [Map("new")]
        New,

        [Map("change")]
        Change,

        [Map("delete")]
        Delete
    }
}
