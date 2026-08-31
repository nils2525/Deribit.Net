using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Deribit.Net.Enums
{
    /// <summary>Deribit account margin model.</summary>
    [JsonConverter(typeof(EnumConverter<DeribitMarginModel>))]
    public enum DeribitMarginModel
    {
        /// <summary>Cross-collateral portfolio margin.</summary>
        [Map("cross_pm")]
        CrossPortfolio,

        /// <summary>Cross-collateral standard margin.</summary>
        [Map("cross_sm")]
        CrossStandard,

        /// <summary>Segregated portfolio margin.</summary>
        [Map("segregated_pm")]
        SegregatedPortfolio,

        /// <summary>Segregated standard margin.</summary>
        [Map("segregated_sm")]
        SegregatedStandard,
    }
}
