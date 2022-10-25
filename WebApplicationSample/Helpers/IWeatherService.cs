namespace WebApplicationSample.Helpers
{
    public interface IWeatherService
    {
        Task<string> Get(string cityName);
    }
}
