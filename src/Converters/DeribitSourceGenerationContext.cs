using System.Text.Json.Serialization;
using Deribit.Net.Enums;
using Deribit.Net.Objects.Internal;
using Deribit.Net.Objects.Models;
using CryptoExchange.Net.Objects;

namespace Deribit.Net.Converters
{
    [JsonSerializable(typeof(DeribitResponse<DeribitCurrency[]>))]
    [JsonSerializable(typeof(DeribitResponse<string[]>))]
    [JsonSerializable(typeof(DeribitResponse<string>))]
    [JsonSerializable(typeof(DeribitResponse<DeribitTest>))]
    [JsonSerializable(typeof(DeribitResponse<DeribitTimestamp>))]
    [JsonSerializable(typeof(DeribitResponse<DeribitTimestamp>))]
    [JsonSerializable(typeof(DeribitResponse<DeribitSymbol[]>))]
    [JsonSerializable(typeof(DeribitResponse<DeribitSymbol>))]
    [JsonSerializable(typeof(DeribitResponse<DeribitCurrency[]>))]
    [JsonSerializable(typeof(DeribitResponse<DeribitTicker>))]
    [JsonSerializable(typeof(DeribitResponse<DeribitTicker[]>))]
    [JsonSerializable(typeof(DeribitResponse<DeribitStatus>))]
    [JsonSerializable(typeof(DeribitResponse<DeribitAccount>))]
    [JsonSerializable(typeof(DeribitResponse<DeribitPlaceOrderResult>))]
    [JsonSerializable(typeof(DeribitResponse<DeribitUserOrder>))]
    [JsonSerializable(typeof(DeribitResponse<DeribitUserOrder[]>))]
    [JsonSerializable(typeof(DeribitResponse<DeribitUserTrade>))]
    [JsonSerializable(typeof(DeribitResponse<DeribitUserTrade[]>))]
    [JsonSerializable(typeof(DeribitResponse<DeribitInstrumentTrades>))]
    [JsonSerializable(typeof(DeribitResponse<DeribitSocketAuthResponse>))]
    [JsonSerializable(typeof(DeribitResponse<DeribitPagedResult<DeribitDeposit>>))]
    [JsonSerializable(typeof(DeribitResponse<DeribitPagedResult<DeribitWithdrawal>>))]


    [JsonSerializable(typeof(DeribitMessage<DeribitHeartbeat>))]

    [JsonSerializable(typeof(DeribitMessage<DeribitTrade[]>))]
    [JsonSerializable(typeof(DeribitMessage<DeribitSubscriptionEvent<DeribitTrade[]>>))]
    [JsonSerializable(typeof(DeribitMessage<DeribitOrderBook>))]
    [JsonSerializable(typeof(DeribitMessage<DeribitSubscriptionEvent<DeribitOrderBook>>))]
    [JsonSerializable(typeof(DeribitMessage<DeribitTicker>))]
    [JsonSerializable(typeof(DeribitMessage<DeribitSubscriptionEvent<DeribitTicker>>))]
    [JsonSerializable(typeof(DeribitMessage<DeribitTicker[]>))]
    [JsonSerializable(typeof(DeribitMessage<DeribitSubscriptionEvent<DeribitTicker[]>>))]
    [JsonSerializable(typeof(DeribitMessage<DeribitUserOrder>))]
    [JsonSerializable(typeof(DeribitMessage<DeribitSubscriptionEvent<DeribitUserOrder>>))]
    [JsonSerializable(typeof(DeribitMessage<DeribitUserTrade[]>))]
    [JsonSerializable(typeof(DeribitMessage<DeribitSubscriptionEvent<DeribitUserTrade[]>>))]
    [JsonSerializable(typeof(DeribitMessage<DeribitAccountBalance>))]
    [JsonSerializable(typeof(DeribitMessage<DeribitSubscriptionEvent<DeribitAccountBalance>>))]

    [JsonSerializable(typeof(DeribitSocketRequest))]

    [JsonSerializable(typeof(DeribitResponseError))]
    [JsonSerializable(typeof(DeribitSocketAuthResponse))]

    [JsonSerializable(typeof(DeribitOrderBookEntryUpdateType))]
    [JsonSerializable(typeof(Parameters))]
    internal partial class DeribitSourceGenerationContext : JsonSerializerContext
    { }
}
