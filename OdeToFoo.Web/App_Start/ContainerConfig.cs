using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace OdeToFoo.Web
{
    public class ContainerConfig
    {
        //Here we add dependency Injections, MUST BE ADDED TO GLOBAL ASAX
        //Design pattern
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();

            //abstractions

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //web API
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            //When I use IRestaurant Data it will use InmemoryRestaurant Data
            builder.RegisterType<InMemoryRestaurantData>()
                .As<IRestaurantData>()
                .SingleInstance();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            //WEB API only
            httpConfiguration.DependencyResolver = (new AutofacWebApiDependencyResolver(container));
        }
    }
}