using Autofac;
using Autofac.Integration.Mvc;
using BIPS.Web;
using BIPS.Web.App_Start;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using UIShell.OSGi.MvcCore;

[assembly: PreApplicationStartMethod(typeof(MvcApplication), "StartBundleRuntime")]
namespace BIPS.Web
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
