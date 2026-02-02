using System.Text.Json.Serialization;

namespace Deribit.Net.Objects.Models
{
    internal class DeribitSocketAuthResponse
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; } = string.Empty;

        [JsonPropertyName("enabled_features")]
        public string[] EnabledFeatures { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Can be used to request a new token (with a new lifetime)
        /// </summary>
        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; } = string.Empty;

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonPropertyName("scope")]
        public string Scope { get; set; } = string.Empty;

        [JsonPropertyName("sid")]
        public string SessionId { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; } = string.Empty;
    }
}
