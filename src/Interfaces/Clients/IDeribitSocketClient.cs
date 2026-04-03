using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Interfaces.Clients;
using CryptoExchange.Net.Objects.Options;
using Deribit.Net.Interfaces.Clients.ExchangeApi;

namespace Deribit.Net.Interfaces.Clients
{
    /// <summary>
    /// Client for accessing the CryptoCom websocket API
    /// </summary>
    public interface IDeribitSocketClient : ISocketClient<HMACCredential>
    {

        /// <summary>
        /// Exchange API endpoints
        /// </summary>
        public IDeribitSocketClientExchangeApi ExchangeApi { get; }
    }
}
