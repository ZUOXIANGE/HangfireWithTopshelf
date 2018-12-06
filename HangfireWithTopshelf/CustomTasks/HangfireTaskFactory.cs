using System.Collections.Generic;
using Hangfire;
using HangfireWithTopshelf.CustomTasks.Implement;
using HangfireWithTopshelf.CustomTasks.Interface;

namespace HangfireWithTopshelf.CustomTasks
{
    public class HangfireTaskFactory
    {
        public static void CreateJobs()
        {
            //TODO 通过反射从配置文件创建任务列表
            var tasks = new List<ITask>
            {
                new SimpleTask()
            };
            foreach (var task in tasks)
            {
                RecurringJob.AddOrUpdate(task.Name, () => task.Run(), task.CronExpression);
            }
        }
    }
}