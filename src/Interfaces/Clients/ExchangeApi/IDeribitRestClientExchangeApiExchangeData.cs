using CryptoExchange.Net.Objects;
using Deribit.Net.Objects.Models;

namespace Deribit.Net.Interfaces.Clients.ExchangeApi
{
    /// <summary>
    /// CryptoCom Exchange exchange data endpoints. Exchange data includes market data (tickers, order books, etc) and system status.
    /// </summary>
    public interface IDeribitRestClientExchangeApiExchangeData
    {
        /// <summary>
        /// Gets the server time
        /// <para><a href="https://docs.deribit.com/#public-get_time" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default);

        /// <summary>
        /// Get symbols/instruments
        /// <para><a href="https://docs.deribit.com/#public-get_instruments" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<DeribitSymbol[]>> GetSymbolsAsync(CancellationToken ct = default);

        /// <summary>
        /// 
        /// <para><a href="https://docs.deribit.com/#public-get_currencies" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<DeribitCurrency[]>> GetCurrencyInformationAsync(CancellationToken ct = default);

        /// <summary>
        /// 
        /// <para><a href="https://docs.deribit.com/#public-ticker" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<DeribitTicker>> GetTickerAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Gets the platform-wide currency and index lock status.
        /// <para><a href="https://docs.deribit.com/api-reference/supporting/public-status" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<DeribitStatus>> GetExchangeStatusAsync(CancellationToken ct = default);
    }
}
