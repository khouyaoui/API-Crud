using Autofac;
using Autofac.Integration.WebApi;
using Student.Business.Logic.BusinessLogic;
using Student.Business.Logic.Contrants;
using Student.Business.Logic.Modules;
using Student.Common.Logic.Log4net;
using System.Reflection;

namespace Student.Business.Facade.Modules
{
    public class StudentApiModule : Autofac.Module
    {
        protected override void Load (ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder
                .RegisterType<StudentBL>()
                .As<IBusiness>()
                .InstancePerRequest();

            builder
                 .RegisterType<Log4netAdapter>()
                .As<ILogger>()
                .InstancePerRequest();

            builder.RegisterModule(new BusinessModule());
            base.Load(builder);
            builder.RegisterGeneric(typeof(FacturaBL<>))
                .As(typeof(IBusinessGeneric<>))
                .AsSelf()
                .InstancePerRequest();
        }
    }
}