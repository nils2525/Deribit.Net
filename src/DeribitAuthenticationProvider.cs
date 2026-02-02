using System.Security.Cryptography;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Objects;

namespace Deribit.Net
{
    internal class DeribitAuthenticationProvider : AuthenticationProvider
    {
        public override ApiCredentialsType[] SupportedCredentialTypes { get; } = [ApiCredentialsType.Hmac];

        public DeribitAuthenticationProvider(ApiCredentials credentials) : base(credentials)
        { }

        public override void ProcessRequest(RestApiClient apiClient, RestRequestConfiguration requestConfig)
        {
            if (!requestConfig.Authenticated)
                return;

            throw new NotImplementedException();
        }

        public ParameterCollection AuthenticateSocket(string? refreshToken)
        {
            if (!String.IsNullOrWhiteSpace(refreshToken))
                return new ParameterCollection()
                {
                    { "refresh_token", refreshToken }
                };

            var key = _credentials.Key;
            var timestamp = DateTimeConverter.ConvertToMilliseconds(DateTime.UtcNow);
            var nonce = new byte[8];
            var data = String.Empty;
            RandomNumberGenerator.Fill(nonce);
            var nonceString = BytesToHexString(nonce).ToLower();
            var signatureText = $"{timestamp}\n{nonceString}\n{data}";

            return new ParameterCollection()
            {
                { "grant_type", "client_signature" },
                { "client_id", _credentials.Key },
                { "timestamp", timestamp },
                { "nonce", nonceString },
                { "data", data },
                { "signature", SignHMACSHA256(signatureText, SignOutputType.Hex).ToLower() },
            };
        }
    }
}
