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
using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Mangtas.Web.Api;
using Microsoft.Ajax.Utilities;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;

namespace Mangtas.Web
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
            
            //Configure AutoMapper
            //AutoMapperConfiguration.Configure();
        }
        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            var config = new HttpConfiguration();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterType<TestController>().InstancePerRequest();
            //builder.RegisterWebApiFilterProvider(config);
            //builder.RegisterType<DataContext>().InstancePerRequest();
            //builder.RegisterType<PersonContext>().As<IDataContextAsync>().InstancePerRequest();
            //builder.RegisterAssemblyTypes(typeof(DataContext).Assembly)
            //.Where(t => t.Name.EndsWith("Context"))
            //.AsImplementedInterfaces().InstancePerRequest();
            //builder.RegisterType(typeof(DataContext)).As<IDataContextAsync>().InstancePerRequest();
            //builder.RegisterAssemblyTypes(typeof(IDataContextAsync).Assembly).AsClosedTypesOf(typeof(IDataContextAsync));
            builder.RegisterType<UnitOfWork>().As<IUnitOfWorkAsync>().InstancePerRequest();


            //builder.RegisterAssemblyTypes(typeof(IRepositoryAsync<>).Assembly).AsClosedTypesOf(typeof(IRepositoryAsync<>));
            //builder.RegisterAssemblyTypes(typeof(IService<>).Assembly).AsClosedTypesOf(typeof(IService<>));
            //builder.RegisterType<Repository<Person>>().As<IRepositoryAsync<Person>>().InstancePerRequest();
            //builder.RegisterType<PersonService>().As<IPersonService>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
           
        }
    }

    //public class DataContextRegistrationSource : IRegistrationSource
    //{

    //    public Boolean IsAdapterForIndividualComponents
    //    {
    //        get { return true; }
    //    }

    //    public IEnumerable<IComponentRegistration> RegistrationsFor(Service service, Func<Service, IEnumerable<IComponentRegistration>> registrationAccessor)
    //    {
    //        if (service == null)
    //        {
    //            throw new ArgumentNullException("service");
    //        }
    //        if (registrationAccessor == null)
    //        {
    //            throw new ArgumentNullException("registrationAccessor");
    //        }

    //        IServiceWithType ts = service as IServiceWithType;
    //        if (ts == null || !(ts.ServiceType.IsGenericType && ts.ServiceType.GetGenericTypeDefinition() == typeof(DataContext<>)))
    //        {
    //            yield break;
    //        }

    //        yield return RegistrationBuilder.ForType(ts.ServiceType)
    //                                        .AsSelf()
    //                                        .WithParameter(new NamedParameter("databaseName", "test"))
    //                                        .WithParameter(new NamedParameter("serverName", "test2"))
    //                                        .CreateRegistration();

    //    }
    //}
}