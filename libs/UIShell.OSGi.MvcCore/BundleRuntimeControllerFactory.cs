using System;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;
using System.Web.Routing;
using UIShell.OSGi.Loader;
using System.Web.SessionState;
using UIShell.OSGi.Utility;

namespace UIShell.OSGi.MvcCore
{
    public class BundleRuntimeControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            //http://localhost:1616/Blog/Index?plugin=BlogPlugin

            var controller = base.CreateController(requestContext, controllerName);
            if (controller == null)
            {
                return controller;
            }

            var resolver = BundleRuntime.Instance.GetFirstOrDefaultService<IInjectionService>();
            if (resolver != null)
            {
                return resolver.InjectProperties(controller);//.Resolve(type) as IController;
            }

            return controller;
        }


        protected override Type GetControllerType(RequestContext requestContext, string controllerName)
        {
            var symbolicName =  requestContext.GetPluginSymbolicName();;
            if (symbolicName != null)
            {
                var controllerType = ControllerTypeCache.GetControllerType(symbolicName, controllerName);
                if (controllerType != null)
                {
                    FileLogUtility.Inform(string.Format("Loaded controller '{0}' from bundle '{1}' by using cache.", controllerName, symbolicName));
                    return controllerType;
                }

                var controllerTypeName = controllerName + "Controller";
                var runtimeService = BundleRuntime.Instance.GetFirstOrDefaultService<IRuntimeService>();
                var assemblies = runtimeService.LoadBundleAssembly((string)symbolicName);

                foreach (var assembly in assemblies)
                {
                    foreach (var type in assembly.GetTypes())
                    {
                        if (type.Name.Contains(controllerTypeName) && typeof(IController).IsAssignableFrom(type))
                        {
                            controllerType = type;
                            ControllerTypeCache.AddControllerType(symbolicName.ToString(), controllerName, controllerType);
                            FileLogUtility.Inform(string.Format("Loaded controller '{0}' from bundle '{1}' and then added to cache.", controllerName, symbolicName));
                            return controllerType;
                        }
                    }
                }

                FileLogUtility.Error(string.Format("Failed to load controller '{0}' from bundle '{1}'.", controllerName, symbolicName));
            }

            try
            {
                //if exists duplicated controller type, below will throw an exception.
               return  base.GetControllerType(requestContext, controllerName);
            }
            catch (Exception)
            {
                //intentionally suppress the duplication error.
            }

            requestContext.RouteData.DataTokens["Namespaces"] = DefaultControllerConfig.DefaultNamespaces;
            var result = base.GetControllerType(requestContext, controllerName);
            if (result != null)
            {
                return result;
            }

            FileLogUtility.Error(string.Format("Failed to load controller '{0}'", controllerName));
            return null;
        }
    }
}