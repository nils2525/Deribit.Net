using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Objects.Options;
using Deribit.Net.Clients.ExchangeApi;
using Deribit.Net.Interfaces.Clients;
using Deribit.Net.Interfaces.Clients.ExchangeApi;
using Deribit.Net.Objects.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Deribit.Net.Clients
{
    /// <inheritdoc cref="IDeribitSocketClient" />
    public class DeribitSocketClient : BaseSocketClient<DeribitEnvironment, HMACCredential>, IDeribitSocketClient
    {
        #region fields
        #endregion

        #region Api clients


        /// <inheritdoc />
        public IDeribitSocketClientExchangeApi ExchangeApi { get; }


        #endregion

        #region constructor/destructor

        /// <summary>
        /// Create a new instance of CryptoComSocketClient
        /// </summary>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public DeribitSocketClient(Action<DeribitSocketOptions>? optionsDelegate = null)
            : this(Options.Create(ApplyOptionsDelegate(optionsDelegate)), null)
        { }

        /// <summary>
        /// Create a new instance of CryptoComSocketClient
        /// </summary>
        /// <param name="loggerFactory">The logger factory</param>
        /// <param name="options">Option configuration</param>
        public DeribitSocketClient(IOptions<DeribitSocketOptions> options, ILoggerFactory? loggerFactory = null) : base(loggerFactory, "Deribit")
        {
            Initialize(options.Value);
            ExchangeApi = AddApiClient(new DeribitSocketClientExchangeApi(loggerFactory, options.Value));
        }
        #endregion

        /// <summary>
        /// Set the default options to be used when creating new clients
        /// </summary>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public static void SetDefaultOptions(Action<DeribitSocketOptions> optionsDelegate)
        {
            DeribitSocketOptions.Default = ApplyOptionsDelegate(optionsDelegate);
        }
    }
}
