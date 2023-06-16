using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace CRI396987485TimeoutLock
{
    public class BadTimerTrigger
    {
        private readonly ILogger _logger;

        public BadTimerTrigger(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<BadTimerTrigger>();
        }

        [Function("BadTimerTrigger")]
        public async Task RunAsync([TimerTrigger("*/10 * * * * *")] MyInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            
            await Task.Delay(TimeSpan.FromHours(4));

            _logger.LogInformation($"Finished TimeSpan.FromHours(4) {DateTime.Now}");
        }
    }

    public class MyInfo
    {
        public MyScheduleStatus ScheduleStatus { get; set; }

        public bool IsPastDue { get; set; }
    }

    public class MyScheduleStatus
    {
        public DateTime Last { get; set; }

        public DateTime Next { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
