using Microsoft.Extensions.DependencyInjection;
using Quartz.Shared.Jobs;

namespace Quartz.Shared.Extensions;
public static class QuartzExtensions
{
    public static void RegisterQuartz(this IServiceCollection services, Action<IServiceCollectionQuartzConfigurator>? action = null)
    {
        // Add the required Quartz.NET services
        services.AddQuartz(q =>
        {
            // Use a Scoped container to create jobs.
            q.UseMicrosoftDependencyInjectionJobFactory();
            if (action != null)
                action(q);
        });
        // Add the Quartz.NET hosted service
        services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
    }

    public static void RegisterJob<T>(this IServiceCollectionQuartzConfigurator quartzConfigurator, string cronSchedule)
        where T : IJob
    {
        var jobKey = new JobKey(typeof(T).Name);

        quartzConfigurator.AddJob<T>(opts => opts.WithIdentity(jobKey))
            .AddTrigger(opts => opts.ForJob(jobKey)
            .WithIdentity($"{jobKey.Name}-trigger")
            .WithCronSchedule(cronSchedule));
    }
}
