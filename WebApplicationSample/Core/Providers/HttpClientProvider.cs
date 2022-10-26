using Ninject;
using System;
using System.Collections.Concurrent;
using WebApplicationSample.Core.Config;

namespace WebApplicationSample.Core.Providers
{
    public class HttpClientProvider : IHttpClientProvider, IInitializable
    {
        private static ConcurrentDictionary<HttpClientType, HttpClient> httpClients = new ConcurrentDictionary<HttpClientType, HttpClient>();

        private Uri baseAddress = new Uri("http://api.weatherapi.com/v1/current.json");

        public void Initialize()
        {
            // create default http client
            HttpClient httpClient = new HttpClient()
            {
                Timeout = TimeSpan.FromSeconds(HttpClientConstants.DefaultTimeoutSeconds),
                BaseAddress = baseAddress
        };

            httpClients.TryAdd(HttpClientType.Default, httpClient);
        }

        public HttpClient GetHttpClient(HttpClientType clientType = HttpClientType.Default, int timeoutSeconds = HttpClientConstants.DefaultTimeoutSeconds)
        {
            if (httpClients.TryGetValue(clientType, out HttpClient client))
            {
                return client;
            }

            // Create httpclient if the specified timeout is not found
            HttpClient httpClient = new HttpClient()
            {
                Timeout = TimeSpan.FromSeconds(timeoutSeconds),
                BaseAddress = baseAddress
            };

            httpClients.TryAdd(clientType, httpClient);

            return httpClient;
        }
    }
}
