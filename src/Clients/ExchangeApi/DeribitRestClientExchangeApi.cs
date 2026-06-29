using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis;
using Deribit.Net.Clients.MessageHandlers;
using Deribit.Net.Interfaces.Clients.ExchangeApi;
using Deribit.Net.Objects.Internal;
using Deribit.Net.Objects.Options;
using Microsoft.Extensions.Logging;

namespace Deribit.Net.Clients.ExchangeApi
{
    /// <inheritdoc cref="IDeribitRestClientExchangeApi" />
    internal partial class DeribitRestClientExchangeApi : RestApiClient<DeribitEnvironment, DeribitAuthenticationProvider, HMACCredential>, IDeribitRestClientExchangeApi
    {
        protected override IRestMessageHandler MessageHandler { get; } = new DeribitRestMessageHandler();

        #region Api clients
        /// <inheritdoc />
        public IDeribitClientExchangeApiAccount Account { get; }
        /// <inheritdoc />
        public IDeribitRestClientExchangeApiExchangeData ExchangeData { get; }
        /// <inheritdoc />
        public IDeribitRestClientExchangeApiTrading Trading { get; }
        /// <inheritdoc />
        public string ExchangeName => "Deribit";
        #endregion

        #region constructor/destructor
        internal DeribitRestClientExchangeApi(ILoggerFactory? loggerFactory, HttpClient? httpClient, DeribitRestOptions options)
            : base(loggerFactory, DeribitExchange.ExchangeName, httpClient, options.Environment.RestClientAddress, options, options.ExchangeOptions)
        {
            Account = new DeribitRestClientExchangeApiAccount(this);
            ExchangeData = new DeribitRestClientExchangeApiExchangeData(_logger, this);
            Trading = new DeribitRestClientExchangeApiTrading(_logger, this);
        }
        #endregion

        /// <inheritdoc />
        protected override IMessageSerializer CreateSerializer()
            => new SystemTextJsonMessageSerializer(SerializerOptions.WithConverters(DeribitExchange.SerializerContext));

        /// <inheritdoc />
        protected override DeribitAuthenticationProvider CreateAuthenticationProvider(HMACCredential credentials)
            => new DeribitAuthenticationProvider(credentials);


        internal Task<HttpResult<T>> SendAsync<T>(RequestDefinition definition, Parameters? parameters, CancellationToken cancellationToken, int? weight = null) where T : class
            => SendToAddressAsync<T>(BaseAddress, definition, parameters, cancellationToken, weight);

        internal async Task<HttpResult<T>> SendToAddressAsync<T>(string baseAddress, RequestDefinition definition, Parameters? parameters, CancellationToken cancellationToken, int? weight = null) where T : class
        {
            definition.BaseAddress = baseAddress;
            var result = await base.SendAsync<DeribitResponse<T>>(definition, parameters, cancellationToken, null, weight).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<T>(result);

            return result.As(result.Data.Data);
        }

        /// <inheritdoc />
        protected override Task<HttpResult<DateTime>> GetServerTimestampAsync()
            => ExchangeData.GetServerTimeAsync();

        /// <inheritdoc />
        public override string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null)
                => DeribitExchange.FormatSymbol(baseAsset, quoteAsset, tradingMode, deliverTime);

    }
}
