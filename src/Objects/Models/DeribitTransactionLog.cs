using System.Text.Json.Serialization;

namespace Deribit.Net.Objects.Models
{
    /// <summary>
    /// A page of transaction log entries.
    /// </summary>
    public class DeribitTransactionLog
    {
        /// <summary>
        /// Transaction log entries.
        /// </summary>
        [JsonPropertyName("logs")]
        public DeribitTransactionLogEntry[] Logs { get; set; } = Array.Empty<DeribitTransactionLogEntry>();

        /// <summary>
        /// Continuation token for the next page, or <see langword="null"/> when there is no next page.
        /// </summary>
        [JsonPropertyName("continuation")]
        public long? Continuation { get; set; }
    }
}
