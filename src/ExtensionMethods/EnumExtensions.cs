using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoExchange.Net.Objects;
using Deribit.Net.Enums;

namespace Deribit.Net.ExtensionMethods
{
    public static class EnumExtensions
    {
        public static SocketUpdateType ToCEN(this DeribitSocketAction action)
            => action switch
            {
                DeribitSocketAction.Update => SocketUpdateType.Update,
                DeribitSocketAction.Snapshot => SocketUpdateType.Snapshot,
                _ => throw new ArgumentException($"Unknown DeribitSocketAction ({action})"),
            };
    }
}
