using CryptoExchange.Net.Objects.Options;

namespace Deribit.Net.Objects.Options
{
    /// <summary>
    /// Options for the CryptoComSocketClient
    /// </summary>
    public class DeribitSocketOptions : SocketExchangeOptions<DeribitEnvironment>
    {
        /// <summary>
        /// Default options for new clients
        /// </summary>
        internal static DeribitSocketOptions Default { get; set; } = new DeribitSocketOptions()
        {
            Environment = DeribitEnvironment.Live,
            SocketSubscriptionsCombineTarget = 10,
            MaxSocketConnections = 2000,
            SocketNoDataTimeout = TimeSpan.FromSeconds(80) // Ping is send every 30 seconds
        };

        /// <summary>
        /// ctor
        /// </summary>
        public DeribitSocketOptions()
        {
            Default?.Set(this);
        }

        /// <summary>
        /// Exchange API options
        /// </summary>
        public SocketApiOptions ExchangeOptions { get; private set; } = new SocketApiOptions();

        internal DeribitSocketOptions Set(DeribitSocketOptions targetOptions)
        {
            targetOptions = base.Set<DeribitSocketOptions>(targetOptions);
            targetOptions.ExchangeOptions = ExchangeOptions.Set(targetOptions.ExchangeOptions);
            return targetOptions;
        }
    }
}
