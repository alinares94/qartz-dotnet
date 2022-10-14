using Microsoft.Extensions.Hosting;
using Quartz.Shared.Extensions;
using Quartz.Shared.Jobs;

await Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    .ConfigureServices(services => {
        services.RegisterQuartz(x => x.RegisterJob<SimpleJob>("0/5 * * * * ?"));
        services.RegisterServices();
    })
    .Build()
    .RunAsync();