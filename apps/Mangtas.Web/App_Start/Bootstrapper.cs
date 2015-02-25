using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using Test.Entities;
using Test.Service;

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
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<PersonContext>().As<IDataContextAsync>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWorkAsync>().InstancePerRequest();

            builder.RegisterType<Repository<Person>>().As<IRepositoryAsync<Person>>().InstancePerRequest();
            builder.RegisterType<PersonService>().As<IPersonService>().InstancePerRequest();

            //builder.Register(_ => new PersonContext())
            //       .As<IDataContextAsync>().InstancePerRequest();
            //builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            //builder.RegisterType<Repository<Person>>().As<IRepositoryAsync<Person>>().InstancePerRequest();

            //builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //builder.RegisterType<PersonContext>().As<IDataContextAsync>().InstancePerRequest();
            //builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            //builder.Register<PersonContext>((_) => new PersonContext()).InstancePerRequest();
            //builder.RegisterType<Repository<Person>>().As<IRepositoryAsync<Person>>().InstancePerRequest();
            //builder.RegisterType<PersonService>().As<IPersonService>().InstancePerRequest();
            //   builder.RegisterAssemblyTypes(typeof(FocusRepository).Assembly)
            //   .Where(t => t.Name.EndsWith("Repository"))
            //   .AsImplementedInterfaces().InstancePerHttpRequest();
            //   builder.RegisterAssemblyTypes(typeof(GoalService).Assembly)
            //  .Where(t => t.Name.EndsWith("Service"))
            //  .AsImplementedInterfaces().InstancePerHttpRequest();

            //   builder.RegisterAssemblyTypes(typeof(DefaultFormsAuthentication).Assembly)
            //.Where(t => t.Name.EndsWith("Authentication"))
            //.AsImplementedInterfaces().InstancePerHttpRequest();

            //   builder.Register(c => new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new SocialGoalEntities())))
            //       .As<UserManager<ApplicationUser>>().InstancePerHttpRequest();

            //builder.RegisterFilterProvider();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}