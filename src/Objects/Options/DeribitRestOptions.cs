using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects.Options;

namespace Deribit.Net.Objects.Options
{
    /// <summary>
    /// Options for the CryptoComRestClient
    /// </summary>
    public class DeribitRestOptions : RestExchangeOptions<DeribitEnvironment, HMACCredential>
    {
        public TimeSpan ReceiveWindow { get; set; } = TimeSpan.FromSeconds(5);

        /// <summary>
        /// Default options for new clients
        /// </summary>
        internal static DeribitRestOptions Default { get; set; } = new DeribitRestOptions()
        {
            Environment = DeribitEnvironment.Live,
            AutoTimestamp = true
        };

        /// <summary>
        /// ctor
        /// </summary>
        public DeribitRestOptions()
        {
            Default?.Set(this);
        }

        /// <summary>
        /// Exchange API options
        /// </summary>
        public RestApiOptions ExchangeOptions { get; private set; } = new RestApiOptions();

        internal DeribitRestOptions Set(DeribitRestOptions targetOptions)
        {
            targetOptions = base.Set<DeribitRestOptions>(targetOptions);
            targetOptions.ExchangeOptions = ExchangeOptions.Set(targetOptions.ExchangeOptions);
            targetOptions.ReceiveWindow = ReceiveWindow;
            return targetOptions;
        }
    }
}
