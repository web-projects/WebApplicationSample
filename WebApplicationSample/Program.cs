namespace WebApplicationSample
{
    /// <summary>
    /// generate API KEY https://www.weatherapi.com/
    /// KEY: 414631bbd9f04003b97204119222510 
    /// PING API
    /// ping api.weatherapi.com: 143.244.50.86
    /// netsat -ano | findstr 143.244.50.86
    /// 
    /// API LAUNCH: https://localhost:7201/weatherforecast?cityName=Los%20Angeles
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Manually create an instance of the Startup class
            var startup = new Startup(builder.Configuration);

            // Manually call ConfigureServices()
            startup.ConfigureServices(builder.Services);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            // Fetch all the dependencies from the DI container 
            // As pointed out by DavidFowler, IHostApplicationLifetime is exposed directly on ApplicationBuilder
            //IHostApplicationLifetime hostLifetime = app.Services.GetRequiredService<IHostApplicationLifetime>();
            IWebHostEnvironment hostEnvironment = app.Services.GetRequiredService<IWebHostEnvironment>();

            // Call Configure(), passing in the dependencies
            startup.Configure(app, hostEnvironment);

            app.Run();
        }
    }
}
