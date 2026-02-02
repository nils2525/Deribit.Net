namespace Deribit.Net.Objects
{
    /// <summary>
    /// Api addresses
    /// </summary>
    public class DeribitApiAddresses
    {
        /// <summary>
        /// The address used by the CryptoComRestClient for the API
        /// </summary>
        public string RestClientAddress { get; set; } = "";
        /// <summary>
        /// The address used by the CryptoComSocketClient for the websocket API
        /// </summary>
        public string SocketClientPublicAddress { get; set; } = "";

        /// <summary>
        /// The default addresses to connect to the CryptoCom API
        /// </summary>
        public static DeribitApiAddresses Default = new DeribitApiAddresses
        {
            RestClientAddress = "https://www.deribit.com",
            SocketClientPublicAddress = "wss://deribit.com/ws/api/v2",
        };
    }
}
