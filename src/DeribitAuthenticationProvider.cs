using System.Security.Cryptography;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Objects;

namespace Deribit.Net
{
    internal class DeribitAuthenticationProvider : AuthenticationProvider<HMACCredential>
    {
        public override string Key => ApiCredentials.Key;

        public DeribitAuthenticationProvider(HMACCredential credentials) : base(credentials)
        { }

        public override void ProcessRequest(RestApiClient apiClient, RestRequestConfiguration requestConfig)
        {
            if (!requestConfig.RequestDefinition.Authenticated)
                return;

            throw new NotImplementedException();
        }

        public Parameters AuthenticateSocket(string? refreshToken)
        {
            if (!String.IsNullOrWhiteSpace(refreshToken))
                return new Parameters(DeribitExchange._parameterSerializationSettings)
                {
                    { "refresh_token", refreshToken }
                };

            var key = ApiCredentials.Key;
            var timestamp = DateTimeConverter.ConvertToMilliseconds(DateTime.UtcNow);
            var nonce = new byte[8];
            var data = String.Empty;
            RandomNumberGenerator.Fill(nonce);
            var nonceString = BytesToHexString(nonce).ToLower();
            var signatureText = $"{timestamp}\n{nonceString}\n{data}";

            return new Parameters(DeribitExchange._parameterSerializationSettings)
            {
                { "grant_type", "client_signature" },
                { "client_id", ApiCredentials.Key },
                { "timestamp", timestamp },
                { "nonce", nonceString },
                { "data", data },
                { "signature", SignHMACSHA256(ApiCredentials, signatureText, SignOutputType.Hex).ToLower() },
            };
        }
    }
}
