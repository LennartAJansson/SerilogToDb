internal class Service : IService
{
    private readonly ILogger<Service> logger;

    public Service(ILogger<Service> logger) => this.logger = logger;

    public Task Execute()
    {
        logger.LogInformation("Execute");
        return Task.CompletedTask;
    }
}