using Deribit.Net.Enums;
using System.Text.Json.Serialization;

namespace Deribit.Net.Objects.Models
{
    public abstract class DeribitSnapshotableData
    {
        [JsonPropertyName("type")]
        public DeribitSocketAction Type { get; set; }
    }
}
