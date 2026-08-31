using System.Text.Json.Serialization;

namespace Deribit.Net.Objects.Models
{
    /// <summary>Per-currency result of a Deribit margin-model change.</summary>
    public class DeribitMarginModelChange
    {
        /// <summary>Currency code.</summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; } = string.Empty;

        /// <summary>Portfolio state before the change.</summary>
        [JsonPropertyName("old_state")]
        public DeribitMarginState OldState { get; set; } = new();

        /// <summary>Portfolio state after the change.</summary>
        [JsonPropertyName("new_state")]
        public DeribitMarginState NewState { get; set; } = new();
    }
}
