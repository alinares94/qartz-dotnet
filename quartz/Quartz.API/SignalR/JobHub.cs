using Microsoft.AspNetCore.SignalR;

namespace Quartz.API.SignalR;

public class JobHub : Hub
{
    public Task SendSignalRJobsMessage(string message)
    {
        return Clients.All.SendAsync(nameof(JobQuartz), message);
    }

}
