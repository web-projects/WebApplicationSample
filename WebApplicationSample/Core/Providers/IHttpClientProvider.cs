using WebApplicationSample.Core.Config;

namespace WebApplicationSample.Core.Providers
{
    public interface IHttpClientProvider
    {
        HttpClient GetHttpClient(HttpClientType clientType = HttpClientType.Default, int timeoutSeconds = HttpClientConstants.DefaultTimeoutSeconds);
    }
}
