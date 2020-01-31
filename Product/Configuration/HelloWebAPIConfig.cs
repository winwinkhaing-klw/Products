using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Product.Configuration
{
    /// <summary>
    /// HelloWeb api.
    /// </summary>
    public class HelloWebAPIConfig
    {
        /// <summary>
        /// Register api.
        /// </summary>
        /// <param name="config">config.</param>
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}