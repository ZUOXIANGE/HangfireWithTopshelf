using System.Configuration;
using System.Net.Http.Formatting;
using System.Web.Http;
using Hangfire;
using Owin;

namespace HangfireWithTopshelf
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new {id = RouteParameter.Optional}
            );
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            app.UseWebApi(config);

            GlobalConfiguration.Configuration.UseSqlServerStorage(ConfigurationManager.ConnectionStrings["Hangfire"]
                .ConnectionString);
            app.UseHangfireDashboard("/jobs");
            app.UseHangfireServer();
        }
    }
}