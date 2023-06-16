using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace CRI396987485TimeoutLock
{
    public class GoodTimerTrigger
    {
        private readonly ILogger _logger;

        public GoodTimerTrigger(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<GoodTimerTrigger>();
        }

        [Function("GoodTimerTrigger")]
        public void Run([TimerTrigger("0 */1 * * * *")] MyInfo myTimer)
        {
            _logger.LogInformation($"~~ GoodTimerTrigger function executed at: {DateTime.Now} ~~");
        }
    }
}
