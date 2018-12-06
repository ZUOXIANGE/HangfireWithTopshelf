using Topshelf;

namespace HangfireWithTopshelf
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<WebServer>(s =>
                {
                    s.ConstructUsing(name => new WebServer());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();

                x.SetDescription("Hangfire Jobs");
                x.SetDisplayName("Hangfire Jobs");
                x.SetServiceName("Hangfire Jobs");

                x.EnableServiceRecovery(rc => { rc.RestartService(1); });
            });
        }
    }
}