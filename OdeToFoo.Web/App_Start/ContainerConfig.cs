using Autofac;
using Autofac.Integration.Mvc;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFoo.Web
{
    public class ContainerConfig
    {
        //Here we add dependency Injections, MUST BE ADDED TO GLOBAL ASAX
        //Design pattern
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            //abstractions

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //When I use IRestaurant Data it will use InmemoryRestaurant Data
            builder.RegisterType<InMemoryRestaurantData>()
                .As<IRestaurantData>()
                .SingleInstance();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}