using Serilog;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddTransient<IService, Service>();
    })
    .UseSerilog((hostingContext, loggerConfiguration) =>
    {
        loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration);
    })
    .Build();

using (host)
{
    await host.StartAsync();
    using (IServiceScope? scope = host.Services.CreateScope())
    {
        await scope.ServiceProvider.GetRequiredService<IService>().Execute();
    }

    await host.StopAsync();
}

