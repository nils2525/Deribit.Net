using System.Net.WebSockets;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default;
using CryptoExchange.Net.Sockets.Interfaces;
using Deribit.Net.Clients.MessageHandlers;
using Deribit.Net.Enums;
using Deribit.Net.ExtensionMethods;
using Deribit.Net.Interfaces.Clients.ExchangeApi;
using Deribit.Net.Objects.Internal;
using Deribit.Net.Objects.Models;
using Deribit.Net.Objects.Options;
using Deribit.Net.Objects.Sockets;
using Deribit.Net.Objects.Sockets.Subscriptions;
using Microsoft.Extensions.Logging;

namespace Deribit.Net.Clients.ExchangeApi
{
    /// <summary>
    /// Client providing access to the CryptoCom Exchange websocket Api
    /// </summary>
    internal partial class DeribitSocketClientExchangeApi : SocketApiClient<DeribitEnvironment, DeribitAuthenticationProvider, HMACCredential>, IDeribitSocketClientExchangeApi
    {
        #region constructor/destructor

        /// <summary>
        /// ctor
        /// </summary>
        internal DeribitSocketClientExchangeApi(ILogger logger, DeribitSocketOptions options) :
            base(logger, options.Environment.SocketClientAddress!, options, options.ExchangeOptions)
        {
            KeepAliveInterval = TimeSpan.Zero;
            RateLimiter = DeribitExchange.RateLimiter.Socket;
            AddSystemSubscription(new DeribitHeartbeatSubscription(_logger));
        }
        #endregion

        private Task<CallResult<Objects.Internal.DeribitResponse<string>>> SendHeartbeatConfigurationAsync(SocketConnection socketConnection)
        {
            return socketConnection.SendAndWaitQueryAsync(new DeribitQuery<string>("/public/set_heartbeat", new ParameterCollection()
            {
                { "interval", 30 }
            }, false));
        }

        private void InitNewConnection(SocketConnection socketConnection)
        {
            async void HandleSocketConnectionRestoredAsync(TimeSpan span)
            {
                try
                {
                    await SendHeartbeatConfigurationAsync(socketConnection);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            void HandleSocketConnectionClosed()
            {
                socketConnection.ConnectionRestored -= HandleSocketConnectionRestoredAsync;
                socketConnection.ConnectionClosed -= HandleSocketConnectionClosed;
            }

            socketConnection.ConnectionRestored += HandleSocketConnectionRestoredAsync;
            socketConnection.ConnectionClosed += HandleSocketConnectionClosed;
        }

        #region Subscriptions

        /// <inheritdoc />
        protected override IMessageSerializer CreateSerializer()
            => new SystemTextJsonMessageSerializer(SerializerOptions.WithConverters(DeribitExchange.SerializerContext));

        /// <inheritdoc />
        protected override DeribitAuthenticationProvider CreateAuthenticationProvider(HMACCredential credentials)
            => new DeribitAuthenticationProvider(credentials);

        protected override async Task<CallResult> ConnectSocketAsync(ISocketConnection socketConnection, CancellationToken ct)
        {
            if (socketConnection is not SocketConnection conn)
                throw new InvalidOperationException("Invalid socket connection type");


            var result = await base.ConnectSocketAsync(socketConnection, ct);
            if (!result)
                return result;

            InitNewConnection(conn);

            var heartheatResult = await SendHeartbeatConfigurationAsync(conn);
            if (!heartheatResult)
                return heartheatResult;

            return result;
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, DeribitSubscriptionInterval interval, Action<DataEvent<DeribitTrade[]>> onMessage, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, DeribitSubscriptionEvent<DeribitTrade[]>>((receiveTime, originalData, data) =>
            {
                DateTime? timestamp = data.Data.Any() ? data.Data.Max(c => c.Timestamp) : null;
                if (timestamp.HasValue)
                    UpdateTimeOffset(timestamp.Value);

                onMessage(
                    new DataEvent<DeribitTrade[]>(DeribitExchange.ExchangeName, data.Data, receiveTime, originalData)
                        .WithUpdateType(SocketUpdateType.Update)
                        .WithSymbol(symbol)
                        .WithStreamId(data.Channel)
                        .WithDataTimestamp(timestamp, GetTimeOffset())
                    );
            });

            var subscription = new DeribitSubscription<DeribitTrade[]>(_logger, $"trades.{symbol}.{EnumConverter.GetString(interval)}", internalHandler, interval is DeribitSubscriptionInterval.Raw);
            return SubscribeAsync(BaseAddress, subscription, ct);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToCandleUpdatesAsync(string symbol, DeribitSubscriptionInterval interval, Action<DataEvent<DeribitCandle[]>> onMessage, CancellationToken ct = default)
        {
            throw new Exception("Not implemented");
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(string symbol, DeribitSubscriptionInterval interval, Action<DataEvent<DeribitOrderBook>> onMessage, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, DeribitSubscriptionEvent<DeribitOrderBook>>((receiveTime, originalData, data) =>
            {
                var timestamp = data.Data.Timestamp;
                UpdateTimeOffset(timestamp);

                onMessage(
                    new DataEvent<DeribitOrderBook>(DeribitExchange.ExchangeName, data.Data, receiveTime, originalData)
                        .WithUpdateType(data.Data.Type.ToCEN())
                        .WithSymbol(data.Data.Symbol)
                        .WithStreamId(data.Channel)
                        .WithDataTimestamp(timestamp, GetTimeOffset())
                    );
            });
            var subscription = new DeribitSubscription<DeribitOrderBook>(_logger, $"book.{symbol}.{EnumConverter.GetString(interval)}", internalHandler, interval is DeribitSubscriptionInterval.Raw);
            return SubscribeAsync(BaseAddress, subscription, ct);
        }

        public Task<CallResult<UpdateSubscription>> SubscribeToTickeUpdatesAsync(string symbol, DeribitSubscriptionInterval interval, Action<DataEvent<DeribitTicker>> onMessage, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, DeribitSubscriptionEvent<DeribitTicker>>((receiveTime, originalData, data) =>
            {
                var timestamp = data.Data.Timestamp;
                UpdateTimeOffset(timestamp);

                onMessage(
                    new DataEvent<DeribitTicker>(DeribitExchange.ExchangeName, data.Data, receiveTime, originalData)
                        .WithUpdateType(SocketUpdateType.Update)
                        .WithSymbol(symbol)
                        .WithStreamId(data.Channel)
                        .WithDataTimestamp(timestamp, GetTimeOffset())
                    );
            });
            var subscription = new DeribitSubscription<DeribitTicker>(_logger, $"ticker.{symbol}.{EnumConverter.GetString(interval)}", internalHandler, interval is DeribitSubscriptionInterval.Raw);
            return SubscribeAsync(BaseAddress, subscription, ct);
        }

        public Task<CallResult<UpdateSubscription>> SubscribeToTickeUpdatesAsync(IEnumerable<string> symbols, DeribitSubscriptionInterval interval, Action<DataEvent<DeribitTicker>> onMessage, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, DeribitSubscriptionEvent<DeribitTicker>>((receiveTime, originalData, data) =>
            {
                var timestamp = data.Data.Timestamp;
                UpdateTimeOffset(timestamp);

                onMessage(
                    new DataEvent<DeribitTicker>(DeribitExchange.ExchangeName, data.Data, receiveTime, originalData)
                        .WithUpdateType(SocketUpdateType.Update)
                        .WithSymbol(data.Data.Symbol)
                        .WithStreamId(data.Channel)
                        .WithDataTimestamp(timestamp, GetTimeOffset())
                    );
            });
            var subscription = new DeribitSubscription<DeribitTicker>(_logger, symbols.Select(symbol => $"ticker.{symbol}.{EnumConverter.GetString(interval)}"), internalHandler, interval is DeribitSubscriptionInterval.Raw);
            return SubscribeAsync(BaseAddress, subscription, ct);
        }

        public Task<CallResult<UpdateSubscription>> SubscribeToUserOrderUpdatesAsync(string symbol, DeribitSubscriptionInterval interval, Action<DataEvent<DeribitUserOrder>> onMessage, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, DeribitSubscriptionEvent<DeribitUserOrder>>((receiveTime, originalData, data) =>
            {
                var timestamp = data.Data.LastUpdateTimestamp;
                UpdateTimeOffset(timestamp);

                onMessage(
                    new DataEvent<DeribitUserOrder>(DeribitExchange.ExchangeName, data.Data, receiveTime, originalData)
                        .WithUpdateType(SocketUpdateType.Update)
                        .WithSymbol(data.Data.InstrumentName)
                        .WithStreamId(data.Channel)
                        .WithDataTimestamp(timestamp, GetTimeOffset())
                    );
            });
            var subscription = new DeribitSubscription<DeribitUserOrder>(_logger, $"user.orders.{symbol}.{EnumConverter.GetString(interval)}", internalHandler, true);
            return SubscribeAsync(BaseAddress, subscription, ct);
        }

        public Task<CallResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(string symbol, DeribitSubscriptionInterval interval, Action<DataEvent<DeribitUserTrade[]>> onMessage, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, DeribitSubscriptionEvent<DeribitUserTrade[]>>((receiveTime, originalData, data) =>
            {
                DateTime? timestamp = data.Data.Any() ? data.Data.Max(c => c.Timestamp) : null;
                if (timestamp.HasValue)
                    UpdateTimeOffset(timestamp.Value);

                onMessage(
                    new DataEvent<DeribitUserTrade[]>(DeribitExchange.ExchangeName, data.Data, receiveTime, originalData)
                        .WithUpdateType(SocketUpdateType.Update)
                        .WithSymbol(symbol)
                        .WithStreamId(data.Channel)
                        .WithDataTimestamp(timestamp, GetTimeOffset())
                    );
            });
            var subscription = new DeribitSubscription<DeribitUserTrade[]>(_logger, $"user.trades.{symbol}.{EnumConverter.GetString(interval)}", internalHandler, true);
            return SubscribeAsync(BaseAddress, subscription, ct);
        }

        public Task<CallResult<UpdateSubscription>> SubscribeToUserPortfolioUpdatesAsync(string? currency, Action<DataEvent<DeribitAccountBalance>> onMessage, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, DeribitSubscriptionEvent<DeribitAccountBalance>>((receiveTime, originalData, data) =>
            {
                onMessage(
                    new DataEvent<DeribitAccountBalance>(DeribitExchange.ExchangeName, data.Data, receiveTime, originalData)
                        .WithUpdateType(SocketUpdateType.Update)
                        .WithSymbol(data.Data.Currency)
                        .WithStreamId(data.Channel)
                        .WithDataTimestamp(receiveTime, null)
                    );
            });
            var subscription = new DeribitSubscription<DeribitAccountBalance>(_logger, $"user.portfolio.{currency ?? "any"}", internalHandler, true);
            return SubscribeAsync(BaseAddress, subscription, ct);
        }
        #endregion

        #region Queries
        protected async Task<CallResult<T>> QueryAsync<T>(DeribitQuery<T> query, CancellationToken ct)
        {
            var response = await base.QueryAsync(query, ct).ConfigureAwait(false);
            if (response.Data?.Error != null)
                response.AsDatalessError(new ServerError(response.Data.Error.Code, new(CryptoExchange.Net.Objects.Errors.ErrorType.Unknown, response.Data.Error.Message)));

            if (response.Error != null)
                return response.AsError<T>(response.Error);

            return response.As(response.Data!.Data);
        }

        internal async Task<bool> SendHeartbeatAsync()
        {
            _logger.LogDebug("Sending heartbeat...");
            var query = new DeribitQuery<DeribitTest>("/public/test", false);
            var response = await QueryAsync(query, CancellationToken.None).ConfigureAwait(false);
            return response.Success;
        }

        public async Task<CallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default)
        {
            var query = new DeribitQuery<DeribitTimestamp>("/public/get_time", false);
            var response = await QueryAsync(query, ct);
            return response.As(response.Data.Timestamp);
        }

        public Task<CallResult<DeribitSymbol[]>> GetSymbolsAsync(CancellationToken ct = default)
        {
            var query = new DeribitQuery<DeribitSymbol[]>("/public/get_instruments", false);
            return QueryAsync(query, ct);
        }

        public Task<CallResult<DeribitSymbol>> GetSymbolAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection { { "instrument_name", symbol } };
            var query = new DeribitQuery<DeribitSymbol>("/public/get_instrument", parameters, false);
            return QueryAsync(query, ct);
        }

        public Task<CallResult<DeribitCurrency[]>> GetCurrencyInformationAsync(CancellationToken ct = default)
        {
            var query = new DeribitQuery<DeribitCurrency[]>("/public/get_currencies", false);
            return QueryAsync(query, ct);
        }

        public Task<CallResult<DeribitTicker>> GetTickerAsync(string symbol, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection { { "instrument_name", symbol } };
            var query = new DeribitQuery<DeribitTicker>("/public/ticker", parameters, false);
            return QueryAsync(query, ct);
        }

        public Task<CallResult<DeribitStatus>> GetExchangeStatusAsync(CancellationToken ct = default)
        {
            var query = new DeribitQuery<DeribitStatus>("/public/status", false);
            return QueryAsync(query, ct);
        }

        public Task<CallResult<DeribitAccount>> GetAccountSummariesAsync(CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "extended", true}
            };
            var query = new DeribitQuery<DeribitAccount>("/private/get_account_summaries", parameters, true);
            return QueryAsync(query, ct);
        }

        public Task<CallResult<DeribitPlaceOrderResult>> PlaceOrderAsync(string symbol, DeribitTradeSide side, DeribitOrderType type, decimal price, decimal quantity, string? label = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "instrument_name", symbol },
                { "amount", quantity },
                { "price", price },
                { "type", EnumConverter.GetString(type) },
            };
            parameters.AddOptional("label", label);
            var query = new DeribitQuery<DeribitPlaceOrderResult>($"/private/{EnumConverter.GetString(side)}", parameters, true);
            return QueryAsync(query, ct);
        }

        public Task<CallResult<DeribitUserOrder>> CancelOrderAsync(string orderId, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "order_id", orderId }
            };
            var query = new DeribitQuery<DeribitUserOrder>("/private/cancel", parameters, true);
            return QueryAsync(query, ct);
        }

        public Task<CallResult<DeribitUserOrder[]>> GetOpenOrdersAsync(DeribitOrderKind kind, DeribitOrderType? type = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "kind", EnumConverter.GetString(kind)   }
            };
            parameters.AddOptional("type", EnumConverter.GetString(type));
            var query = new DeribitQuery<DeribitUserOrder[]>("/private/get_open_orders", parameters, true);
            return QueryAsync(query, ct);
        }

        public Task<CallResult<DeribitUserOrder>> GetOrderAsync(string orderId, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "order_id", orderId }
            };
            var query = new DeribitQuery<DeribitUserOrder>("/private/get_order_state", parameters, true);
            return QueryAsync(query, ct);
        }
        public Task<CallResult<DeribitUserTrade[]>> GetOrderTradesAsync(string orderId, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "order_id", orderId }
            };
            var query = new DeribitQuery<DeribitUserTrade[]>("/private/get_user_trades_by_order", parameters, true);
            return QueryAsync(query, ct);
        }

        public Task<CallResult<DeribitInstrumentTrades>> GetUserTradesByInstrumentAsync(string instrument, long? startSequence = null, long? endSequence = null, int? count = null, DateTime? startTime = null, DateTime? endTime = null, bool historical = false, DeribitSortOrder sortOrder = DeribitSortOrder.Default, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                { "instrument_name", instrument }
            };
            parameters.AddOptional("start_seq", startSequence);
            parameters.AddOptional("end_seq", endSequence);
            parameters.AddOptional("count", count);
            parameters.AddOptionalMilliseconds("start_time", startTime);
            parameters.AddOptionalMilliseconds("end_time", endTime);
            parameters.AddOptional("historical", historical);
            parameters.AddOptional("sort_order", EnumConverter.GetString(sortOrder));

            var query = new DeribitQuery<DeribitInstrumentTrades>("/private/get_user_trades_by_instrument", parameters, true);
            return QueryAsync(query, ct);
        }

        public Task<CallResult<DeribitPagedResult<DeribitDeposit>>> GetDepositsAsync(string currency, int? count = null, int? offset = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                {"currency", currency }
            };
            parameters.AddOptional("count", count);
            parameters.AddOptional("offset", offset);
            var query = new DeribitQuery<DeribitPagedResult<DeribitDeposit>>("/private/get_deposits", parameters, true);
            return QueryAsync(query, ct);
        }

        public Task<CallResult<DeribitPagedResult<DeribitWithdrawal>>> GetWithdrawalsAsync(string currency, int? count = null, int? offset = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection()
            {
                {"currency", currency }
            };
            parameters.AddOptional("count", count);
            parameters.AddOptional("offset", offset);
            var query = new DeribitQuery<DeribitPagedResult<DeribitWithdrawal>>("/private/get_withdrawals", parameters, true);
            return QueryAsync(query, ct);
        }
        #endregion

        public override ISocketMessageHandler CreateMessageConverter(WebSocketMessageType messageType)
            => new DeribitSocketMessageHandler();

        protected override Task<Query?> GetAuthenticationRequestAsync(SocketConnection connection)
        {
            var authProvider = (DeribitAuthenticationProvider)AuthenticationProvider!;
            var authParams = authProvider.AuthenticateSocket(null);
            return Task.FromResult<Query?>(new DeribitQuery<DeribitSocketAuthResponse>("public/auth", authParams, false, 1));
        }

        //public override async Task<CallResult> AuthenticateSocketAsync(SocketConnection socket)
        //{
        //
        //    var response = await socket.SendAndWaitQueryAsync(query);
        //
        //    if (!(socket.Authenticated = response.Success))
        //        return response;
        //
        //    return new CallResult(null);
        //}

        /// <inheritdoc />
        public override string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null)
                => DeribitExchange.FormatSymbol(baseAsset, quoteAsset, tradingMode, deliverTime);
    }
}
