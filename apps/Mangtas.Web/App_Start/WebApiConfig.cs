using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using Service.Pattern;

namespace Mangtas.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            
            // Web API routes

            var builder = new ContainerBuilder();
            var assembly = Assembly.GetExecutingAssembly();
            var allassemblies = AppDomain.CurrentDomain.GetAssemblies();

            builder.RegisterControllers(assembly);
            builder.RegisterApiControllers(assembly);

            builder.RegisterControllers(allassemblies);
            builder.RegisterApiControllers(allassemblies);

            builder.RegisterAssemblyTypes(allassemblies)
               .Where(t => t.Name.Contains("BukContext") && typeof(DataContext).IsAssignableFrom(t))
               .As<IDataContextAsync>().InstancePerRequest();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWorkAsync>().InstancePerRequest();
           
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepositoryAsync<>)).InstancePerRequest();
            builder.RegisterAssemblyTypes(allassemblies)
               .Where(t => t.Name.Contains("BukService"))
               .As(t => t.GetInterfaces().Single(i => i.Name == "I" + t.Name)).InstancePerRequest();
            

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
