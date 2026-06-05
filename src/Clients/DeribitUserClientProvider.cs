using System.Collections.Concurrent;
using CryptoExchange.Net.Authentication;
using Deribit.Net.Interfaces.Clients;
using Deribit.Net.Objects.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Deribit.Net.Clients
{
    /// <inheritdoc />
    public class DeribitUserClientProvider : IDeribitUserClientProvider
    {
        private static ConcurrentDictionary<string, IDeribitRestClient> _restClients = new ConcurrentDictionary<string, IDeribitRestClient>();
        private static ConcurrentDictionary<string, IDeribitSocketClient> _socketClients = new ConcurrentDictionary<string, IDeribitSocketClient>();

        private readonly IOptions<DeribitRestOptions> _restOptions;
        private readonly IOptions<DeribitSocketOptions> _socketOptions;
        private readonly HttpClient _httpClient;
        private readonly ILoggerFactory? _loggerFactory;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="optionsDelegate">Options to use for created clients</param>
        public DeribitUserClientProvider(Action<DeribitOptions>? optionsDelegate = null)
            : this(null, null, Options.Create(ApplyOptionsDelegate(optionsDelegate).Rest), Options.Create(ApplyOptionsDelegate(optionsDelegate).Socket))
        {
        }

        /// <summary>
        /// ctor
        /// </summary>
        public DeribitUserClientProvider(
            HttpClient? httpClient,
            ILoggerFactory? loggerFactory,
            IOptions<DeribitRestOptions> restOptions,
            IOptions<DeribitSocketOptions> socketOptions)
        {
            _httpClient = httpClient ?? new HttpClient();
            _loggerFactory = loggerFactory;
            _restOptions = restOptions;
            _socketOptions = socketOptions;
        }

        /// <inheritdoc />
        public void InitializeUserClient(string userIdentifier, HMACCredential credentials, DeribitEnvironment? environment = null)
        {
            CreateRestClient(userIdentifier, credentials, environment);
            CreateSocketClient(userIdentifier, credentials, environment);
        }

        /// <inheritdoc />
        public IDeribitRestClient GetRestClient(string userIdentifier, HMACCredential? credentials = null, DeribitEnvironment? environment = null)
        {
            if (!_restClients.TryGetValue(userIdentifier, out var client))
                client = CreateRestClient(userIdentifier, credentials, environment);

            return client;
        }

        /// <inheritdoc />
        public IDeribitSocketClient GetSocketClient(string userIdentifier, HMACCredential? credentials = null, DeribitEnvironment? environment = null)
        {
            if (!_socketClients.TryGetValue(userIdentifier, out var client))
                client = CreateSocketClient(userIdentifier, credentials, environment);

            return client;
        }

        private IDeribitRestClient CreateRestClient(string userIdentifier, HMACCredential? credentials, DeribitEnvironment? environment)
        {
            var clientRestOptions = SetRestEnvironment(environment);
            var client = new DeribitRestClient(_httpClient, _loggerFactory, clientRestOptions);
            if (credentials != null)
            {
                client.SetApiCredentials(credentials);
                _restClients[userIdentifier] = client;
            }
            return client;
        }

        private IDeribitSocketClient CreateSocketClient(string userIdentifier, HMACCredential? credentials, DeribitEnvironment? environment)
        {
            var clientSocketOptions = SetSocketEnvironment(environment);
            var client = new DeribitSocketClient(clientSocketOptions!, _loggerFactory);
            if (credentials != null)
            {
                client.SetApiCredentials(credentials);
                _socketClients[userIdentifier] = client;
            }
            return client;
        }

        private IOptions<DeribitRestOptions> SetRestEnvironment(DeribitEnvironment? environment)
        {
            if (environment == null)
                return _restOptions;

            var newRestClientOptions = new DeribitRestOptions();
            var restOptions = _restOptions.Value.Set(newRestClientOptions);
            newRestClientOptions.Environment = environment;
            return Options.Create(newRestClientOptions);
        }

        private IOptions<DeribitSocketOptions> SetSocketEnvironment(DeribitEnvironment? environment)
        {
            if (environment == null)
                return _socketOptions;

            var newSocketClientOptions = new DeribitSocketOptions();
            var restOptions = _socketOptions.Value.Set(newSocketClientOptions);
            newSocketClientOptions.Environment = environment;
            return Options.Create(newSocketClientOptions);
        }

        private static T ApplyOptionsDelegate<T>(Action<T>? del) where T : new()
        {
            var opts = new T();
            del?.Invoke(opts);
            return opts;
        }
    }
}
