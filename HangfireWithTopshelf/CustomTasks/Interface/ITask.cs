using System.Threading.Tasks;

namespace HangfireWithTopshelf.CustomTasks.Interface
{
    public interface ITask
    {
        /// <summary>
        ///     任务名称
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     Cron表达式
        /// </summary>
        string CronExpression { get; }

        /// <summary>
        ///     任务方法
        /// </summary>
        Task Run();
    }
}