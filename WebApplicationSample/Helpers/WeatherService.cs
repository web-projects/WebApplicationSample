namespace WebApplicationSample.Helpers
{
    public class WeatherService : IWeatherService
    {
        private HttpClient httpClient;

        public WeatherService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
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