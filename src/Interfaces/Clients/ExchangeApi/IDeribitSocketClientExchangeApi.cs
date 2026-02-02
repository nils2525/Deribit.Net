using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Interfaces.Clients;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using Deribit.Net.Enums;
using Deribit.Net.Objects.Models;

namespace Deribit.Net.Interfaces.Clients.ExchangeApi
{
    /// <summary>
    /// CryptoCom Exchange streams
    /// </summary>
    public interface IDeribitSocketClientExchangeApi : ISocketApiClient, IDisposable
    {
        /// <summary>
        /// Gets the server time
        /// <para><a href="https://docs.deribit.com/#public-get_time" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<CallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default);

        /// <summary>
        /// Get symbols/instruments
        /// <para><a href="https://docs.deribit.com/#public-get_instruments" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<CallResult<DeribitSymbol[]>> GetSymbolsAsync(CancellationToken ct = default);

        /// <summary>
        /// Get symbols/instruments
        /// <para><a href="https://docs.deribit.com/#public-get_instruments" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<CallResult<DeribitSymbol>> GetSymbolAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// 
        /// <para><a href="https://docs.deribit.com/#public-get_currencies" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<CallResult<DeribitCurrency[]>> GetCurrencyInformationAsync(CancellationToken ct = default);

        /// <summary>
        /// 
        /// <para><a href="https://docs.deribit.com/#public-ticker" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<CallResult<DeribitTicker>> GetTickerAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// 
        /// <para><a href="https://docs.deribit.com/#public-status" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<CallResult<DeribitStatus>> GetExchangeStatusAsync(CancellationToken ct = default);

        /// <summary>
        /// <para><a href="https://docs.deribit.com/#private-get_account_summaries" /></para>
        /// </summary>
        Task<CallResult<DeribitAccount>> GetAccountSummariesAsync(CancellationToken ct = default);

        /// <summary>
        /// <para><a href="https://docs.deribit.com/#private-buy" /></para>
        /// </summary>
        Task<CallResult<DeribitPlaceOrderResult>> PlaceOrderAsync(string symbol, DeribitTradeSide side, DeribitOrderType type, decimal price, decimal quantity, string? label = null, CancellationToken ct = default);

        /// <summary>
        /// <para><a href="https://docs.deribit.com/#private-cancel" /></para>
        /// </summary>
        Task<CallResult<DeribitUserOrder>> CancelOrderAsync(string orderId, CancellationToken ct = default);

        /// <summary>
        /// <para><a href="https://docs.deribit.com/#private-get_open_orders" /></para>
        /// </summary>
        Task<CallResult<DeribitUserOrder[]>> GetOpenOrdersAsync(DeribitOrderKind kind, DeribitOrderType? type = null, CancellationToken ct = default);

        /// <summary>
        /// <para><a href="https://docs.deribit.com/#private-get_order_state" /></para>
        /// </summary>
        Task<CallResult<DeribitUserOrder>> GetOrderAsync(string orderId, CancellationToken ct = default);

        /// <summary>
        /// <para><a href="https://docs.deribit.com/#private-get_order_state" /></para>
        /// </summary>
        Task<CallResult<DeribitUserTrade[]>> GetOrderTradesAsync(string orderId, CancellationToken ct = default);

        /// <summary>
        /// <para><a href="https://docs.deribit.com/#private-get_user_trades_by_instrument" /></para>
        /// </summary>
        /// <param name="instrument"></param>
        /// <param name="startSequence">The sequence number of the first trade to be returned</param>
        /// <param name="endSequence">The sequence number of the last trade to be returned</param>
        /// <param name="count">Number of requested items, default - 10</param>
        /// <param name="startTime">The earliest timestamp to return result from (milliseconds since the UNIX epoch). When param is provided trades are returned from the earliest</param>
        /// <param name="endTime">The most recent timestamp to return result from (milliseconds since the UNIX epoch). Only one of params: start_timestamp, end_timestamp is truly required</param>
        /// <param name="historical">
        /// Determines whether historical trade and order records should be retrieved.
        /// <list type="bullet">
        ///     <item>false (default): Returns recent records: orders for 30 min, trades for 24h.</item>
        ///     <item>true: Fetches historical records, available after a short delay due to indexing. Recent data is not included.</item>
        /// </list>
        /// </param>
        /// <param name="sortOrder">Direction of results sorting (default value means no sorting, results will be returned in order in which they left the database)</param>
        Task<CallResult<DeribitInstrumentTrades>> GetUserTradesByInstrumentAsync(string instrument, long? startSequence = null, long? endSequence = null, int? count = null, DateTime? startTime = null, DateTime? endTime = null, bool historical = false, DeribitSortOrder sortOrder = DeribitSortOrder.Default, CancellationToken ct = default);

        /// <summary>
        /// <para><a href="https://docs.deribit.com/#private-get_deposits"/></para>
        /// </summary>
        Task<CallResult<DeribitPagedResult<DeribitDeposit>>> GetDepositsAsync(string currency, int? count = null, int? offset = null, CancellationToken ct = default);

        /// <summary>
        /// <para><a href="https://docs.deribit.com/#private-get_withdrawals"/></para>
        /// </summary>
        Task<CallResult<DeribitPagedResult<DeribitWithdrawal>>> GetWithdrawalsAsync(string currency, int? count = null, int? offset = null, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to trade updates
        /// <para><a href="https://api-docs.Deribit.com/spot/websocket/market-data#trades" /></para>
        /// </summary>
        Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, DeribitSubscriptionInterval interval, Action<DataEvent<DeribitTrade[]>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to candle updates
        /// <para><a href="https://api-docs.Deribit.com/spot/websocket/market-data#candlesticks" /></para>
        /// </summary>
        Task<CallResult<UpdateSubscription>> SubscribeToCandleUpdatesAsync(string symbol, DeribitSubscriptionInterval interval, Action<DataEvent<DeribitCandle[]>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to candle updates
        /// <para><a href="https://api-docs.Deribit.com/spot/websocket/market-data#candlesticks" /></para>
        /// </summary>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(string symbol, DeribitSubscriptionInterval interval, Action<DataEvent<DeribitOrderBook>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// <para><a href="https://docs.deribit.com/#ticker-instrument_name-interval" /></para>
        /// </summary>
        Task<CallResult<UpdateSubscription>> SubscribeToTickeUpdatesAsync(string symbol, DeribitSubscriptionInterval interval, Action<DataEvent<DeribitTicker>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// <para><a href="https://docs.deribit.com/#ticker-instrument_name-interval" /></para>
        /// </summary>
        Task<CallResult<UpdateSubscription>> SubscribeToTickeUpdatesAsync(IEnumerable<string> symbols, DeribitSubscriptionInterval interval, Action<DataEvent<DeribitTicker>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// <para><a href="https://docs.deribit.com/#user-orders-instrument_name-raw" /></para>
        /// </summary>
        Task<CallResult<UpdateSubscription>> SubscribeToUserOrderUpdatesAsync(string symbol, DeribitSubscriptionInterval interval, Action<DataEvent<DeribitUserOrder>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// <para><a href="https://docs.deribit.com/#user-trades-instrument_name-interval" /></para>
        /// </summary>
        Task<CallResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(string symbol, DeribitSubscriptionInterval interval, Action<DataEvent<DeribitUserTrade[]>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// <para><a href="https://docs.deribit.com/#user-portfolio-currency" /></para>
        /// </summary>
        Task<CallResult<UpdateSubscription>> SubscribeToUserPortfolioUpdatesAsync(string? currency, Action<DataEvent<DeribitAccountBalance>> onMessage, CancellationToken ct = default);
    }
}
