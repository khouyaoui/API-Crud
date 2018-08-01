using Autofac;
using Autofac.Integration.WebApi;
using System.Web.Http;
using Student.Business.Facade.Modules;

namespace Student.Business.Facade.App_Start
{
    public class AutofacConfigure
    {
        public static Autofac.IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new StudentApiModule());

            var container = builder.Build();

            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;

            return container;

        }
    }
}