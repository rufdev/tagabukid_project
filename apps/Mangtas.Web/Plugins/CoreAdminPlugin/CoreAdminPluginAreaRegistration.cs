using System.Web.Mvc;

namespace CoreAdminPlugin
{
    public class CoreAdminPluginAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "CoreAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "CoreAdminPlugin",
                "CoreAdmin/{controller}/{action}/{id}",
                new { controller= "Admin", action = "Index", id = UrlParameter.Optional },
                new string[] { "CoreAdminPlugin.Controllers" }
            );
        }
    }
}
