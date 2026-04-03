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
        internal DeribitRestClientExchangeApi(ILogger logger, HttpClient? httpClient, DeribitRestOptions options)
            : base(logger, httpClient, options.Environment.RestClientAddress, options, options.ExchangeOptions)
        {
            Account = new DeribitRestClientExchangeApiAccount(this);
            ExchangeData = new DeribitRestClientExchangeApiExchangeData(logger, this);
            Trading = new DeribitRestClientExchangeApiTrading(logger, this);
        }
        #endregion

        /// <inheritdoc />
        protected override IMessageSerializer CreateSerializer()
            => new SystemTextJsonMessageSerializer(SerializerOptions.WithConverters(DeribitExchange.SerializerContext));

        /// <inheritdoc />
        protected override DeribitAuthenticationProvider CreateAuthenticationProvider(HMACCredential credentials)
            => new DeribitAuthenticationProvider(credentials);


        internal Task<WebCallResult<T>> SendAsync<T>(RequestDefinition definition, ParameterCollection? parameters, CancellationToken cancellationToken, int? weight = null) where T : class
            => SendToAddressAsync<T>(BaseAddress, definition, parameters, cancellationToken, weight);

        internal async Task<WebCallResult<T>> SendToAddressAsync<T>(string baseAddress, RequestDefinition definition, ParameterCollection? parameters, CancellationToken cancellationToken, int? weight = null) where T : class
        {
            var result = await base.SendAsync<DeribitResponse<T>>(baseAddress, definition, parameters, cancellationToken, null, weight).ConfigureAwait(false);
            if (!result)
                return result.As<T>(default);

            return result.As(result.Data.Data);
        }

        /// <inheritdoc />
        protected override Task<WebCallResult<DateTime>> GetServerTimestampAsync()
            => ExchangeData.GetServerTimeAsync();

        /// <inheritdoc />
        public override string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null)
                => DeribitExchange.FormatSymbol(baseAsset, quoteAsset, tradingMode, deliverTime);

    }
}
