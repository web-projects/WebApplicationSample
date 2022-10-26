using Ninject;

namespace WebApplicationSample.Core.Providers
{
    internal sealed class WeatherServiceProviderImpl : IInitializable, IWeatherServiceProvider
    {
        [Inject]
        public IHttpClientProvider HttpClientProvider { get; set; }

        public void Initialize()
        {
            
        }

        public HttpClient GetHttpClient()
        {
            return HttpClientProvider.GetHttpClient();
        }
    }
}
