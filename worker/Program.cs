using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        // Register your database context or custom services here if needed
        // e.g., services.AddDbContext<MyDbContext>(...);
        // Just and Example
    })
    .Build();

host.Run();