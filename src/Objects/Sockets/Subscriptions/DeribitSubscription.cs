using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default;
using Deribit.Net.Objects.Internal;
using Microsoft.Extensions.Logging;
using CryptoExchange.Net.Sockets.Default.Routing;

namespace Deribit.Net.Objects.Sockets.Subscriptions
{
    /// <inheritdoc />
    internal class DeribitSubscription<T> : Subscription
    {
        /// <inheritdoc />

        private readonly string[] _channels;
        private readonly Action<DateTime, string?, DeribitSubscriptionEvent<T>> _handler;

        /// <summary>
        /// ctor
        /// </summary>
        public DeribitSubscription(ILogger logger, string channel, Action<DateTime, string?, DeribitSubscriptionEvent<T>> handler, bool auth)
            : this(logger, [channel], handler, auth)
        { }

        public DeribitSubscription(ILogger logger, IEnumerable<string> channels, Action<DateTime, string?, DeribitSubscriptionEvent<T>> handler, bool auth) : base(logger, auth)
        {
            _handler = handler;
            _channels = channels.ToArray();
            IndividualSubscriptionCount = _channels.Length;

            MessageRouter = MessageRouter.Create(channels.Select(c => MessageRoute<DeribitMessage<DeribitSubscriptionEvent<T>>>.CreateWithoutTopicFilter(c, DoHandleMessage)).ToArray());
        }

        /// <inheritdoc />
        protected override Query? GetSubQuery(SocketConnection connection)
            => new DeribitQuery<string[]>(Authenticated ? "/private/subscribe" : "/public/subscribe", new ParameterCollection()
            {
                { "channels", _channels }
            }, Authenticated);

        /// <inheritdoc />
        protected override Query? GetUnsubQuery(SocketConnection connection)
            => new DeribitQuery<string[]>(Authenticated ? "/private/unsubscribe" : "/public/unsubscribe", new ParameterCollection()
            {
                { "channels", _channels }
            }, Authenticated);

        public CallResult DoHandleMessage(SocketConnection connection, DateTime receiveTime, string? originalData, DeribitMessage<DeribitSubscriptionEvent<T>> message)
        {
            _handler.Invoke(receiveTime, originalData, message.Data);
            return CallResult.SuccessResult;
        }
    }
}
