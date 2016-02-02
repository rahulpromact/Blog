using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegistrationAndLogging2.Models;
using RegistrationAndLogging2.Controllers;
using Autofac.Integration.Mvc;
using System.Web.Mvc;

namespace RegistrationAndLogging2.Models
{
    public class Autofac
    {
        public static void start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterGeneric(typeof(BlogRepository<>)).As(typeof(IBlogRepository<>)).InstancePerLifetimeScope();
            builder.RegisterControllers(typeof(BlogsController).Assembly);
            builder.RegisterType<ApplicationDbContext>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}