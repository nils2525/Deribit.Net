using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Interfaces.Clients;

namespace Deribit.Net.Interfaces.Clients.ExchangeApi
{
    /// <summary>
    /// CryptoCom Exchange API endpoints
    /// </summary>
    public interface IDeribitRestClientExchangeApi : IRestApiClient, IDisposable
    {
        /// <summary>
        /// Endpoints related to account settings, info or actions
        /// </summary>
        public IDeribitClientExchangeApiAccount Account { get; }

        /// <summary>
        /// Endpoints related to retrieving market and system data
        /// </summary>
        public IDeribitRestClientExchangeApiExchangeData ExchangeData { get; }

        /// <summary>
        /// Endpoints related to orders and trades
        /// </summary>
        public IDeribitRestClientExchangeApiTrading Trading { get; }
    }
}
