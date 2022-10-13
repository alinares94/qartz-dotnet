namespace Quartz.Shared.Services;
public class LogService : ILogService
{
    private const string LOG_DIRECTORY = @"C:\Quartz\Logs\";
    public async Task LogDateTimeTrace()
    {
        try
        {
            if (!Directory.Exists(LOG_DIRECTORY))
                Directory.CreateDirectory(LOG_DIRECTORY);

            string path = $"{LOG_DIRECTORY}log.txt";
            await using StreamWriter writer = new(path, true);
            writer.WriteLine("Log Time: " + DateTime.Now);
            writer.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }
    }
}

public interface ILogService
{
    Task LogDateTimeTrace();
}