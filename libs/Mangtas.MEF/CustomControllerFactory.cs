﻿using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;


namespace Mangtas.MEF
{
    public class CustomControllerFactory : IControllerFactory
    {
        private readonly DefaultControllerFactory _defaultControllerFactory;

        public CustomControllerFactory()
        {
            _defaultControllerFactory = new DefaultControllerFactory();
        }

        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            var controller = ModuleBootstrapper.GetInstance<IController>(controllerName);

            if (controller == null)
                throw new Exception("Controller not found!");

            return controller;
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            var disposableController = controller as IDisposable;

            if (disposableController != null)
            {
                disposableController.Dispose();
            }
        }
    }
}