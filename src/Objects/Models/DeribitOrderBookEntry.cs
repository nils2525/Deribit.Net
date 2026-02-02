using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Interfaces;
using Deribit.Net.Enums;

namespace Deribit.Net.Objects.Models
{
    [JsonConverter(typeof(ArrayConverter<DeribitOrderBookEntry>))]
    public class DeribitOrderBookEntry : ISymbolOrderBookEntry
    {
        [ArrayProperty(1)]
        public decimal Price { get; set; }

        [ArrayProperty(2)]
        public decimal Quantity { get; set; }

        decimal ISymbolOrderBookEntry.Quantity
        {
            get => Type == DeribitOrderBookEntryUpdateType.Delete ? 0 : Quantity;
            set => Quantity = value;
        }

        [ArrayProperty(0)]
        public DeribitOrderBookEntryUpdateType Type { get; set; }
    }
}
