using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Autofac;
using System.Reflection;
using DAGStore.Data.Infrastructure;
using DAGStore.Data.Repositories;
using DAGStore.Service;
using System.Web.Mvc;
using System.Web.Http;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using DAGStore.Data;
using DotNetOpenAuth.OAuth;
using DAGStore.Model.Models;
using Autofac.Features.ResolveAnything;

[assembly: OwinStartup(typeof(DAGStore.Web.App_Start.Startup))]

namespace DAGStore.Web.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            ConfigAutofac(app);
        }
        private void ConfigAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()); //Register WebApi Controllers

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            builder.RegisterType<DAGStoreDbContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<SecuritySettings>().As<SecuritySettings>();
            //builder.RegisterType<Category>().AsSelf().As<DAGStoreDbContext>().InstancePerLifetimeScope();
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

            // Repositories
            builder.RegisterAssemblyTypes(typeof(MenuRecordRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            // Services
            builder.RegisterAssemblyTypes(typeof(MenuRecordService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();

            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container); //Set the WebApi DependencyResolver

        }
    }
}