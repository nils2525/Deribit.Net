using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Deribit.Net.Enums
{
    [JsonConverter(typeof(EnumConverter<DeribitOrderCancelReason>))]
    public enum DeribitOrderCancelReason
    {
        [Map("user_request")]
        UserRequest,

        [Map("autoliquidation")]
        AutoLiquidation,

        [Map("cancel_on_disconnect")]
        CancelOnDisconnect,

        [Map("risk_mitigation")]
        RiskMitigation,

        [Map("pme_risk_reduction")]
        PmeRiskReduction,

        [Map("pme_account_locked")]
        PmeAccountLocked,

        [Map("position_locked")]
        PositionLocked,

        [Map("mmp_trigger")]
        MmpTrigger,

        [Map("mmp_config_curtailment")]
        MmpConfigCurtailment,

        [Map("edit_post_only_reject")]
        EditPostOnlyReject,

        [Map("reject_post_only")]
        RejectPostOnly,

        [Map("oco_other_closed")]
        OcoOtherClosed,

        [Map("oto_primary_closed")]
        OtoPrimaryClosed,

        [Map("settlement")]
        Settlement,
    }
}
