using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Interfaces.Clients;
using CryptoExchange.Net.Objects.Options;
using Deribit.Net.Interfaces.Clients.ExchangeApi;

namespace Deribit.Net.Interfaces.Clients
{
    /// <summary>
    /// Client for accessing the CryptoCom Rest API. 
    /// </summary>
    public interface IDeribitRestClient : IRestClient<HMACCredential>
    {

        /// <summary>
        /// Exchange API endpoints
        /// </summary>
        public IDeribitRestClientExchangeApi ExchangeApi { get; }
    }
}
