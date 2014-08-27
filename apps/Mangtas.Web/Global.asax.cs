using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Mangtas.Web;
using UIShell.OSGi.MvcCore;

[assembly: PreApplicationStartMethod(typeof(MvcApplication), "StartBundleRuntime")]
namespace Mangtas.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void StartBundleRuntime()
        {
            //Start OSGi
            var bootstapper = new Bootstrapper();
            bootstapper.StartBundleRuntime();
        }

        protected void Application_Start()
        {
            //Register Razor view engine for bundle.
            ViewEngines.Engines.Add(new BundleRuntimeViewEngine(new BundleRazorViewEngineFactory()));
            //Register WebForm view engine.
            ViewEngines.Engines.Add(new BundleRuntimeViewEngine(new BundleWebFormViewEngineFactory()));

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Register the default controller provider source.
            DefaultControllerConfig.Register(typeof(MvcApplication).Assembly);
        }
    }


}
