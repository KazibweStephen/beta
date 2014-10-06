using System.Web.Mvc;
using System.Web.Routing;

namespace WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.MapPageRoute("Tickets", "Reports/Tickets", "~/gbl/Uploadxml.aspx?process=1");
            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}
