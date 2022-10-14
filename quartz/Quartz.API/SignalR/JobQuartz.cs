using Microsoft.AspNetCore.SignalR;

namespace Quartz.API.SignalR;

public class JobQuartz : IJob
{
    private readonly ILogger<JobQuartz> _logger;
    private readonly IHubContext<JobHub> _hubContext;

    public JobQuartz(ILogger<JobQuartz> logger, IHubContext<JobHub> hubContext)
    {
        _logger = logger;
        _hubContext = hubContext;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        var msg = $"SignalR Quartz at {DateTime.UtcNow}";
        _logger.LogInformation(msg);
        await _hubContext.Clients.All.SendAsync(nameof(JobQuartz), msg);
    }
}
