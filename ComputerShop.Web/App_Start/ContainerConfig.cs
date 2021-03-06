﻿using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using ComputerShop.Data.Services;
using System.Web.Http;
using System.Web.Mvc;

namespace ComputerShop.Web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<SqlShopData>()
                .As<IShopData>()
                .InstancePerRequest();
            builder.RegisterType<ComputerShopDbContext>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}