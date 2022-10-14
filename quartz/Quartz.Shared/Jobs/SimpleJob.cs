using Microsoft.Extensions.Logging;

namespace Quartz.Shared.Jobs;
public class SimpleJob : IJob
{
    private readonly ILogger<SimpleJob> _logger;

    public SimpleJob(ILogger<SimpleJob> logger)
    {
        _logger = logger;
    }

    public Task Execute(IJobExecutionContext context)
    {
        var msg = $"Simple Quartz at {DateTime.UtcNow}";
        _logger.LogInformation(msg);
        return Task.CompletedTask;
    }
}