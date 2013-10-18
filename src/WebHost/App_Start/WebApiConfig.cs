using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Hosting;
using WebApiBook.Hosting.Common;

namespace WebHost
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );

            config.Services.Replace(typeof (IHostBufferPolicySelector),
                new ConstantBufferPolicySelector(false));
        }
    }
}
