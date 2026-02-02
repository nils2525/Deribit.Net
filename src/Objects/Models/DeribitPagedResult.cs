using System.Text.Json.Serialization;

namespace Deribit.Net.Objects.Models
{
    public class DeribitPagedResult<T>
    {
        /// <summary>
        /// Total number of results available
        /// </summary>
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("data")]
        public T[] Data { get; set; } = [];
    }
}
