using Autofac;
using Autofac.Integration.Mvc;
using ComputerShop.Data.Services;
using System.Web.Mvc;

namespace ComputerShop.Web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<InMemoryRepairData>()
                .As<IRepairData>()
                .SingleInstance();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}