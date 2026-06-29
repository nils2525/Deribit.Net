using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Objects.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Deribit.Net.Clients.ExchangeApi;
using Deribit.Net.Interfaces.Clients;
using Deribit.Net.Interfaces.Clients.ExchangeApi;
using Deribit.Net.Objects.Options;

namespace Deribit.Net.Clients
{
    /// <inheritdoc cref="IDeribitRestClient" />
    public class DeribitRestClient : BaseRestClient<DeribitEnvironment, HMACCredential>, IDeribitRestClient
    {
        #region Api clients


        /// <inheritdoc />
        public IDeribitRestClientExchangeApi ExchangeApi { get; }


        #endregion

        #region constructor/destructor

        /// <summary>
        /// Create a new instance of the CryptoComRestClient using provided options
        /// </summary>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public DeribitRestClient(Action<DeribitRestOptions>? optionsDelegate = null)
            : this(null, null, Options.Create(ApplyOptionsDelegate(optionsDelegate)))
        {
        }

        /// <summary>
        /// Create a new instance of the CryptoComRestClient using provided options
        /// </summary>
        /// <param name="options">Option configuration</param>
        /// <param name="loggerFactory">The logger factory</param>
        /// <param name="httpClient">Http client for this client</param>
        public DeribitRestClient(HttpClient? httpClient, ILoggerFactory? loggerFactory, IOptions<DeribitRestOptions> options) : base(loggerFactory, "Deribit")
        {
            Initialize(options.Value);

            ExchangeApi = AddApiClient(new DeribitRestClientExchangeApi(loggerFactory, httpClient, options.Value));
        }

        #endregion

        /// <summary>
        /// Set the default options to be used when creating new clients
        /// </summary>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public static void SetDefaultOptions(Action<DeribitRestOptions> optionsDelegate)
        {
            DeribitRestOptions.Default = ApplyOptionsDelegate(optionsDelegate);
        }
    }
}
