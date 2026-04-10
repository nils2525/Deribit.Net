using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default;
using CryptoExchange.Net.Sockets.Default.Routing;
using Deribit.Net.Objects.Internal;
using Deribit.Net.Objects.Models;
using Microsoft.Extensions.Logging;

namespace Deribit.Net.Objects.Sockets.Subscriptions
{
    internal class DeribitHeartbeatSubscription : SystemSubscription
    {
        public DeribitHeartbeatSubscription(ILogger logger) : base(logger, false)
        {
            MessageRouter = MessageRouter.CreateWithoutTopicFilter<DeribitMessage<DeribitHeartbeat>>("heartbeat", HandleMessage);
        }

        protected override Query? GetUnsubQuery(SocketConnection connection)
            => new DeribitQuery<string>("/public/disable_heartbeat", false);

        public CallResult HandleMessage(SocketConnection connection, DateTime receiveTime, string? originalData, DeribitMessage<DeribitHeartbeat> message)
        {
            if (message.Data.Type == "test_request")
            {
                _logger.LogDebug("Sending heartbeat...");
                var query = new DeribitQuery<DeribitTest>("/public/test", false);
                Task.Run(() => connection.SendAndWaitQueryAsync(query));
            }

            return CallResult.SuccessResult;
        }
    }
}
