using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.RateLimiting;
using CryptoExchange.Net.RateLimiting.Interfaces;
using CryptoExchange.Net.SharedApis;
using Deribit.Net.Converters;

namespace Deribit.Net
{
    /// <summary>
    /// Deribit exchange information and configuration
    /// </summary>
    public static class DeribitExchange
    {
        internal static DeribitSourceGenerationContext SerializerContext { get; } = new DeribitSourceGenerationContext();

        /// <summary>
        /// Exchange name
        /// </summary>
        public static string ExchangeName => "Deribit";

        /// <summary>
        /// Exchange name
        /// </summary>
        public static string DisplayName => "deribit.com";

        /// <summary>
        /// Url to exchange image
        /// </summary>
        public static string ImageUrl { get; } = "https://docs.deribit.com/#deribit-api-v2-1-1";

        /// <summary>
        /// Url to the main website
        /// </summary>
        public static string Url { get; } = "https://www.deribit.com";

        /// <summary>
        /// Urls to the API documentation
        /// </summary>
        public static string[] ApiDocsUrl { get; } = new[] {
            "https://docs.deribit.com/#deribit-api-v2-1-1"
            };

        /// <summary>
        /// Type of exchange
        /// </summary>
        public static ExchangeType Type { get; } = ExchangeType.CEX;

        /// <summary>
        /// Format a base and quote asset to a Crypto.com recognized symbol 
        /// </summary>
        /// <param name="baseAsset">Base asset</param>
        /// <param name="quoteAsset">Quote asset</param>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="deliverTime">Delivery time for delivery futures</param>
        /// <returns></returns>
        public static string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null)
        {
            if (tradingMode == TradingMode.Spot)
                return $"{baseAsset.ToUpperInvariant()}_{quoteAsset.ToUpperInvariant()}";

            if (tradingMode.IsPerpetual())
                return $"{baseAsset.ToUpperInvariant()}{quoteAsset.ToUpperInvariant()}-PERP";

            if (deliverTime == null)
                throw new ArgumentException("DeliverDate required to format delivery futures symbol");

            return $"{baseAsset.ToUpperInvariant()}{quoteAsset.ToUpperInvariant()}-{deliverTime.Value.ToString("yyMMdd")}";
        }

        /// <summary>
        /// Rate limiter configuration for the Deribit API
        /// </summary>
        public static DeribitRateLimiters RateLimiter { get; } = new DeribitRateLimiters();
    }

    /// <summary>
    /// Rate limiter configuration for the Deribit API
    /// </summary>
    public class DeribitRateLimiters
    {
        /// <summary>
        /// Event for when a rate limit is triggered
        /// </summary>
        public event Action<RateLimitEvent> RateLimitTriggered;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        internal DeribitRateLimiters()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            Initialize();
        }

        private void Initialize()
        {

            RestPrivate = new RateLimitGate("Rest Private");
            RestPrivateSpecific = new RateLimitGate("Rest Private Specific");
            RestPublic = new RateLimitGate("Rest Public");
            RestPublicSpecific = new RateLimitGate("Rest Public Specific");

            Socket = new RateLimitGate("Socket")
                //.AddGuard(new RateLimitGuard(RateLimitGuard.PerHost, [], 5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding))
                //.AddGuard(new RateLimitGuard(RateLimitGuard.PerHost, new PathStartFilter("/private"), 30, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding))
                ;

            RestPrivate.RateLimitTriggered += (x) => RateLimitTriggered?.Invoke(x);
            RestPrivateSpecific.RateLimitTriggered += (x) => RateLimitTriggered?.Invoke(x);
            RestPublic.RateLimitTriggered += (x) => RateLimitTriggered?.Invoke(x);
            RestPublicSpecific.RateLimitTriggered += (x) => RateLimitTriggered?.Invoke(x);
            Socket.RateLimitTriggered += (x) => RateLimitTriggered?.Invoke(x);
        }


        internal IRateLimitGate RestPrivate { get; private set; }
        internal IRateLimitGate RestPrivateSpecific { get; private set; }
        internal IRateLimitGate RestPublic { get; private set; }
        internal IRateLimitGate RestPublicSpecific { get; private set; }
        internal IRateLimitGate Socket { get; private set; }

    }
}
