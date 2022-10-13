using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Program;
using Quartz.Shared.Services;

await Host.CreateDefaultBuilder(args)
    //.UseWindowsService()
    .ConfigureServices(services => {
        ConfigureQuartzService(services);
        ConfigureDIServices(services);
    })
    .Build()
    .RunAsync();

void ConfigureQuartzService(IServiceCollection services)
{
    // Add the required Quartz.NET services
    services.AddQuartz(q =>
    {
        // Use a Scoped container to create jobs.
        q.UseMicrosoftDependencyInjectionJobFactory();
        q.RegisterJobs();
    });
    // Add the Quartz.NET hosted service
    services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
}

void ConfigureDIServices(IServiceCollection services)
{
    services.AddSingleton<ILogService, LogService>();
}