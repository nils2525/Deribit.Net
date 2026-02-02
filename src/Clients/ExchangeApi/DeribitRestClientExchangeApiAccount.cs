using CryptoExchange.Net.Objects;
using Deribit.Net.Interfaces.Clients.ExchangeApi;

namespace Deribit.Net.Clients.ExchangeApi
{
    /// <inheritdoc />
    internal class DeribitRestClientExchangeApiAccount : IDeribitClientExchangeApiAccount
    {
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();
        private readonly DeribitRestClientExchangeApi _baseClient;

        internal DeribitRestClientExchangeApiAccount(DeribitRestClientExchangeApi baseClient)
        {
            _baseClient = baseClient;
        }
    }
}
