using System.Threading.Tasks;
using Hangfire;
using HangfireWithTopshelf.CustomTasks.Interface;
using NLog;

namespace HangfireWithTopshelf.CustomTasks.Implement
{
    public class SimpleTask : ITask
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public string Name => "SimpleTask";

        public string CronExpression => Cron.Minutely();

        public async Task Run()
        {
            _logger.Info("Test Task Begin");

            string content = await Task.FromResult(Name);

            _logger.Info($"Test Task:{content}");
        }
    }
}