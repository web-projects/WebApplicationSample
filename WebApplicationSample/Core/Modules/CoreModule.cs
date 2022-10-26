using Ninject.Modules;
using WebApplicationSample.Core.Providers;

namespace WebApplicationSample.Core.Modules
{
    public sealed class CoreModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IHttpClientProvider>().To<HttpClientProvider>().InSingletonScope();
            Bind<IWeatherServiceProvider>().To<WeatherServiceProviderImpl>().InSingletonScope();
        }
    }
}
