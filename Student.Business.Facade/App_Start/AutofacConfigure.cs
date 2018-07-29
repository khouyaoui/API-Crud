using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Http;
using Autofac;
using Student.Business.Facade;
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