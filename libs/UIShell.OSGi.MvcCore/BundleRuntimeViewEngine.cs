using System.Collections.Concurrent;
using System.Web.Mvc;

namespace UIShell.OSGi.MvcCore
{
    public class BundleRuntimeViewEngine : IViewEngine
    {
        private readonly ConcurrentDictionary<string, IBundleViewEngine> _viewEngines =
            new ConcurrentDictionary<string, IBundleViewEngine>();

        public BundleRuntimeViewEngine(IBundleViewEngineFactory viewEngineFactory)
        {
            this.BundleViewEngineFactory = viewEngineFactory;
            BundleRuntime.Instance.Framework.EventManager.AddBundleEventListener(BundleEventListener, true);
            BundleRuntime.Instance.Framework.EventManager.AddFrameworkEventListener(FrameworkEventListener);

            BundleRuntime.Instance.Framework.Bundles.ForEach(AddViewEngine);
        }

        public ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName,
                                                bool useCache)
        {
            var viewEngine = GetViewEngine(controllerContext);
            if (viewEngine != null)
            {
                return viewEngine.FindPartialView(controllerContext, partialViewName, useCache);
            }
            return new ViewEngineResult(new string[0]);
        }

        public ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName,
                                         bool useCache)
        {
            var viewEngine = GetViewEngine(controllerContext);
            if (viewEngine != null)
            {
                return viewEngine.FindView(controllerContext, viewName, masterName, useCache);
            }
            return new ViewEngineResult(new string[0]);
        }

        public void ReleaseView(ControllerContext controllerContext, IView view)
        {
            var viewEngine = GetViewEngine(controllerContext);
            if (viewEngine != null)
            {
                viewEngine.ReleaseView(controllerContext, view);
            }
        }

        private void FrameworkEventListener(object sender, FrameworkEventArgs args)
        {
            if (args.EventType == FrameworkEventType.Stopped)
            {
                BundleRuntime.Instance.Framework.EventManager.RemoveBundleEventListener(BundleEventListener, true);
                BundleRuntime.Instance.Framework.EventManager.RemoveFrameworkEventListener(FrameworkEventListener);
            }
        }

        private void BundleEventListener(object sender, BundleStateChangedEventArgs args)
        {
            if (args.CurrentState == BundleState.Active)
            {
                AddViewEngine(args.Bundle);
            }
            else if (args.CurrentState == BundleState.Stopping)
            {
                RemoveViewEngine(args.Bundle);
            }
        }

        public IBundleViewEngineFactory BundleViewEngineFactory { get; private set; }

        private void AddViewEngine(IBundle bundle)
        {
            _viewEngines.TryAdd(bundle.SymbolicName, BundleViewEngineFactory.CreateViewEngine(bundle));
        }

        private void RemoveViewEngine(IBundle bundle)
        {
            IBundleViewEngine tmp;
            _viewEngines.TryRemove(bundle.SymbolicName,out tmp);
        }

        private IViewEngine GetViewEngine(ControllerContext controllerContext)
        {
            object symbolicName = controllerContext.GetPluginSymbolicName();
            if (symbolicName == null)
            {
                return null;
            }

            IBundleViewEngine tmp;
            if (_viewEngines.TryGetValue(symbolicName.ToString(), out tmp))
            {
                return tmp;
            }

            return null;
        }
    }
}