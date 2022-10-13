using Quartz.Shared.Services;

namespace Quartz.Program;
internal static class Extensions
{
    internal static void RegisterJobs(this IServiceCollectionQuartzConfigurator q)
    {
        q.RegisterTaskJob();
    }


    internal static void RegisterTaskJob(this IServiceCollectionQuartzConfigurator q)
    {
        // Create a "key" for the job
        var jobKey = new JobKey(nameof(TaskJob));
        // Register the job with the DI container
        q.AddJob<TaskJob>(opts => opts.WithIdentity(jobKey));
        // Create a trigger for the job
        q.AddTrigger(opts => opts.ForJob(jobKey) // link to the Task1
            .WithIdentity($"{nameof(TaskJob)}-trigger") // give the trigger a unique name
            .WithCronSchedule("0/20 * * * * ?")); // run every 5 seconds
    }
}
