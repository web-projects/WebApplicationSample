namespace WebApplicationSample.Core.Providers
{
    public interface IWeatherServiceProvider
    {
        HttpClient GetHttpClient();
    }
}