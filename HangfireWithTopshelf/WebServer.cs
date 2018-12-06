using System;
using HangfireWithTopshelf.CustomTasks;
using Microsoft.Owin.Hosting;

namespace HangfireWithTopshelf
{
    public class WebServer
    {
        private IDisposable _webserver;

        public void Start()
        {
            _webserver = WebApp.Start<Startup>("http://localhost:5000");
            HangfireTaskFactory.CreateJobs();
        }

        public void Stop()
        {
            _webserver?.Dispose();
        }
    }
}