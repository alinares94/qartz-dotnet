namespace Quartz.Shared.Services;
public class TaskJob : IJob
{
    private readonly ILogService _logService;

    public TaskJob(ILogService logService)
    {
        _logService = logService;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        await _logService.LogDateTimeTrace();
        await Console.Out.WriteLineAsync("Hello Job!");
    }
}