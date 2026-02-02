using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Deribit.Net.Enums
{
    [JsonConverter(typeof(EnumConverter<DeribitSortOrder>))]
    public enum DeribitSortOrder
    {
        [Map("asc")]
        Ascending,

        [Map("desc")]
        Descending,

        /// <summary>
        /// No sorting, results will be returned in order in which they left the database
        /// </summary>
        [Map("default")]
        Default,
    }
}
