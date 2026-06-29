using CryptoExchange.Net.Objects;
using Deribit.Net.Interfaces.Clients.ExchangeApi;
using Deribit.Net.Objects.Models;
using Microsoft.Extensions.Logging;

namespace Deribit.Net.Clients.ExchangeApi
{
    /// <inheritdoc />
    internal class DeribitRestClientExchangeApiExchangeData : IDeribitRestClientExchangeApiExchangeData
    {
        private readonly DeribitRestClientExchangeApi _baseClient;
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();

        internal DeribitRestClientExchangeApiExchangeData(ILogger logger, DeribitRestClientExchangeApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Get Server Time

        /// <inheritdoc />
        public async Task<HttpResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default)
        {
            // No dedicated endpoint, use ticker endpoint which returns a timestamp
            var request = _definitions.GetOrCreate(HttpMethod.Get, "api/v2/public/get_time", DeribitExchange.RateLimiter.RestPublic, 1, false);
            var result = await _baseClient.SendAsync<DeribitTimestamp>(request, null, ct).ConfigureAwait(false);
            return result.As(result.Data.Timestamp);
        }

        #endregion

        #region Get Symbols

        /// <inheritdoc />
        public async Task<HttpResult<DeribitSymbol[]>> GetSymbolsAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "api/v2/public/get_instruments", DeribitExchange.RateLimiter.RestPublicSpecific, 1, false);
            var result = await _baseClient.SendAsync<DeribitSymbol[]>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        /// <inheritdoc />
        public async Task<HttpResult<DeribitCurrency[]>> GetCurrencyInformationAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "api/v2/public/get_currencies", DeribitExchange.RateLimiter.RestPublicSpecific, 1, false);
            var result = await _baseClient.SendAsync<DeribitCurrency[]>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        public async Task<HttpResult<DeribitTicker[]>> GetTickersAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "api/v2/public/ticker", DeribitExchange.RateLimiter.RestPublicSpecific, 1, false);
            var result = await _baseClient.SendAsync<DeribitTicker[]>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        public async Task<HttpResult<DeribitTicker>> GetTickerAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new Parameters(DeribitExchange._parameterSerializationSettings) {
                { "instrument_name", symbol}
            };

            var request = _definitions.GetOrCreate(HttpMethod.Get, $"api/v2/public/ticker", DeribitExchange.RateLimiter.RestPublicSpecific, 1, false, parameterPosition: HttpMethodParameterPosition.InUri);
            var result = await _baseClient.SendAsync<DeribitTicker>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        public Task<HttpResult<DeribitStatus>> GetExchangeStatusAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, $"api/v2/public/status", DeribitExchange.RateLimiter.RestPublicSpecific, 1, false);
            return _baseClient.SendAsync<DeribitStatus>(request, null, ct);
        }
        #endregion

    }
}
