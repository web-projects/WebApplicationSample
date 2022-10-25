using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplicationSample.Helpers;

namespace WebApplicationSample.Controllers
{
    /// <summary>
    /// documentation
    /// https://www.youtube.com/watch?v=bAXZx0zOeCU&t=1152s
    /// https://learn.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        //private readonly HttpClient httpClient;

        /// <summary>
        /// https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory
        /// </summary>
        //private readonly IHttpClientFactory? httpClientFactory;

        private readonly IWeatherService weatherService;

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //public WeatherForecastController(ILogger<WeatherForecastController> logger, IHttpClientFactory _httpClientFactory)
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            //httpClient = new HttpClient();
            //httpClientFactory = _httpClientFactory;
            this.weatherService = weatherService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<string> Get(string cityName)
        {
            //string url = $"http://api.weatherapi.com/v1/current.json?key=414631bbd9f04003b97204119222510 &q={cityName}&aqi=no";

            //HttpClient httpClient = httpClientFactory.CreateClient("weather");
            //HttpResponseMessage response = await httpClient.GetAsync(url);
            //return await response.Content.ReadAsStringAsync();

            return await weatherService.Get(cityName);
        }
    }
}
