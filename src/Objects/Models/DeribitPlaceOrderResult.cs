using System.Text.Json.Serialization;

namespace Deribit.Net.Objects.Models
{
    public class DeribitPlaceOrderResult
    {
        [JsonPropertyName("order")]
        public DeribitUserOrder Order { get; set; } = new DeribitUserOrder();

        [JsonPropertyName("trades")]
        public List<DeribitUserTrade> Trades { get; set; } = new List<DeribitUserTrade>();
    }
}
