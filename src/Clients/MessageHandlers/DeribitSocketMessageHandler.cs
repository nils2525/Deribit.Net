using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Converters.SystemTextJson.MessageHandlers;

namespace Deribit.Net.Clients.MessageHandlers
{
    internal class DeribitSocketMessageHandler : JsonSocketMessageHandler
    {
        public override JsonSerializerOptions Options { get; } = SerializerOptions.WithConverters(DeribitExchange.SerializerContext);

        public DeribitSocketMessageHandler()
        {

        }

        protected override MessageTypeDefinition[] TypeEvaluators { get; } = [
            new MessageTypeDefinition {
                Fields = [new PropertyFieldReference("id")],
                TypeIdentifierCallback = x => x.FieldValue("id")!,
            },
            new MessageTypeDefinition {
                Fields = [new PropertyFieldReference("method").WithNotEqualConstraint("subscription")],
                TypeIdentifierCallback = x => x.FieldValue("method")!,
            },
            new MessageTypeDefinition {
                Fields = [new PropertyFieldReference("channel") { Depth = 2 }],
                TypeIdentifierCallback = x => x.FieldValue("channel")!,
            },
        ];
    }
}
