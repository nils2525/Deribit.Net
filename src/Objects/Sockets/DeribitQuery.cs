using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default;
using CryptoExchange.Net.Sockets.Default.Routing;
using Deribit.Net.Objects.Internal;

namespace Deribit.Net.Objects.Sockets
{
    internal class DeribitSubQuery : DeribitQuery<string[]>
    {
        private readonly string[] _channels;

        public DeribitSubQuery(string[] channels, bool authenticated)
            : base(authenticated ? "/private/subscribe" : "/public/subscribe", authenticated)
        {
            this._channels = channels;
        }
    }

    internal class DeribitUnsubQuery : DeribitQuery<DeribitResponse<string[]>>
    {
        public DeribitUnsubQuery(string[] channels, bool authenticated)
            : base(authenticated ? "/private/unsubscribe" : "/public/unsubscribe", authenticated)
        { }
    }

    internal class DeribitQuery<T> : DeribitQueryBase<DeribitResponse<T>>
    {
        public DeribitQuery(DeribitSocketRequest request, bool authenticated, int weight = 1)
            : base(request, authenticated, weight)
        { }

        public DeribitQuery(string method, bool authenticated, int weight = 1)
            : base(new(method), authenticated, weight)
        { }

        public DeribitQuery(string method, Parameters parameters, bool authenticated, int weight = 1)
            : base(new(method, parameters), authenticated, weight)
        { }
    }

    internal abstract class DeribitQueryBase<T> : Query<T>
        where T : DeribitSocketResponseBase
    {
        public DeribitQueryBase(DeribitSocketRequest request, bool authenticated, int weight)
            : base(request, authenticated, weight)
        {
            MessageRouter = MessageRouter.CreateForQuery<T>(request.Id.ToString(), HandleMessage);
        }

        public CallResult<T> HandleMessage(SocketConnection connection, DateTime receiveTime, string? originalData, T message)
        {
            if (message.Error != null)
                return CallResult.Fail<T>(new ServerError(message.Error.Code, new ErrorInfo(ErrorType.Unknown, false, message.Error.Message)));

            return CallResult.Ok(message, originalData);
        }
    }
}
