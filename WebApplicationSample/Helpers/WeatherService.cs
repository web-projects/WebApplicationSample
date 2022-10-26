using Ninject;
using WebApplicationSample.Core;
using WebApplicationSample.Core.Providers;

namespace WebApplicationSample.Helpers
{
    public class WeatherService : IInitializable, IWeatherService
    {
        private HttpClient httpClient;

        [Inject]
        private IWeatherServiceProvider WeatherServiceProvider { get; set; }

        //public WeatherService()
        //{
        //    using IKernel kernel = new AppKernelResolver().ResolveKernel();
        //    kernel.Inject(this);
        //}

        public WeatherService(HttpClient httpClient)
        {
            //this.httpClient = httpClient;
            using IKernel kernel = new AppKernelResolver().ResolveKernel();
            kernel.Inject(this);
        }

        public void Initialize()
        {
            httpClient = WeatherServiceProvider.GetHttpClient();
        }

        public async Task<string> Get(string cityName)
        {
            string apiKey = "414631bbd9f04003b97204119222510";
            string apiUrl = $"?key={apiKey}&q={cityName}";

            var response =  await httpClient.GetAsync(apiUrl);
            return await response.Content.ReadAsStringAsync();
        }
    }
}