using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UIShell.OSGi.MvcCore
{
    public static class Extensions
    {
        public static string GetPluginSymbolicName(this System.Web.Routing.RequestContext requestContext)
        {
            return requestContext.HttpContext.GetPluginSymbolicName();
        }

        public static string GetPluginSymbolicName(this ControllerContext requestContext)
        {
            return requestContext.HttpContext.GetPluginSymbolicName();
        }

        public static string GetPluginSymbolicName(this HttpContextBase context)
        {
            string areaName = context.Request.RequestContext.RouteData.GetAreaName();
            if (areaName != null)
            {
                return areaName + "Plugin";
            }
            return context.Request.QueryString["plugin"];
        }

        public static string GetAreaName(this RouteBase route)
        {
            IRouteWithArea routeWithArea = route as IRouteWithArea;
            if (routeWithArea != null)
            {
                return routeWithArea.Area;
            }
            Route castRoute = route as Route;
            if (castRoute != null && castRoute.DataTokens != null)
            {
                return castRoute.DataTokens["area"] as string;
            }
            return null;
        }

        public static string GetAreaName(this RouteData routeData)
        {
            object area;
            if (routeData.DataTokens.TryGetValue("area", out area))
            {
                return area as string;
            }
            return routeData.Route.GetAreaName();
        }
    }
}