using System.Runtime.Remoting.Messaging;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebUI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
           
          //  config.EnableCors(new EnableCorsAttribute(origins: "*", headers: "*", methods: "*"));
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional }
            );
        }
    }
}
