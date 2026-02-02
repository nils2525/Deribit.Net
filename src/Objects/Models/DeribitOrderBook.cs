using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Deribit.Net.Objects.Models
{
    public class DeribitOrderBook : DeribitSnapshotableData
    {
        [JsonPropertyName("timestamp")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("instrument_name")]
        public string Symbol { get; set; } = String.Empty;

        /// <summary>
        /// The id of the previous message
        /// </summary>
        [JsonPropertyName("prev_change_id")]
        public long PreviousSequence { get; set; }

        /// <summary>
        /// The id of the record (SeqId)
        /// </summary>
        [JsonPropertyName("change_id")]
        public long Sequence { get; set; }

        [JsonPropertyName("bids")]
        public IEnumerable<DeribitOrderBookEntry> Bids { get; set; } = Array.Empty<DeribitOrderBookEntry>();

        [JsonPropertyName("asks")]
        public IEnumerable<DeribitOrderBookEntry> Asks { get; set; } = Array.Empty<DeribitOrderBookEntry>();
    }
}
