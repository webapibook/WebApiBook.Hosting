using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using Owin;

namespace WebApiBook.Hosting.Owin.SelfHosted.Sample1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string baseUri = "http://localhost:8000";
            Trace.Listeners.Add(new ConsoleTraceListener());
            using (WebApp.Start<Startup>(new StartOptions(baseUri)))
            {
                Console.WriteLine("Application is started...");
                Console.ReadKey();
            }
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            app.UseWebApi(config);

            Console.WriteLine("Configuration is done");
        }
    }

    public class ResourceController : ApiController
    {
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage
            {
                Content = new StringContent("Hello Web")
            };
        }
    }
}
