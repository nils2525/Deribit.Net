using System;
using System.Net.Http.Headers;
using System.Text.Json;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Converters.SystemTextJson.MessageHandlers;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;

namespace Deribit.Net.Clients.MessageHandlers
{
    /// <summary>
    /// Parses Deribit JSON-RPC REST responses.
    /// </summary>
    internal class DeribitRestMessageHandler : JsonRestMessageHandler
    {
        /// <inheritdoc />
        public override JsonSerializerOptions Options { get; } = SerializerOptions.WithConverters(DeribitExchange.SerializerContext);

        /// <inheritdoc />
        public override async ValueTask<Error> ParseErrorResponse(int httpStatusCode, HttpResponseHeaders responseHeaders, Stream responseStream)
        {
            var (parseError, document) = await GetJsonDocument(responseStream).ConfigureAwait(false);
            if (parseError != null)
                return parseError;

            var root = document!.RootElement;
            var error = root.TryGetProperty("error", out var errorProperty) && errorProperty.ValueKind is JsonValueKind.Object
                ? errorProperty
                : root;
            var code = error.TryGetProperty("code", out var codeProperty) ? codeProperty.ToString() : httpStatusCode.ToString();
            var message = error.TryGetProperty("message", out var messageProperty) ? messageProperty.GetString() : null;

            return new ServerError(code, new(ErrorType.Unknown, message ?? String.Empty));
        }
    }
}
