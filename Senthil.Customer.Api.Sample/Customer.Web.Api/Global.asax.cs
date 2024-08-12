using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Customer.Web.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //// Create the builder with which components/services are registered.
            //var builder = new ContainerBuilder();

            //// Register types that expose interfaces...
            //builder.RegisterType<WebApp.Models.ICustomerRepository>().As<WebApp.Repository.Database.CustomerRepository>().SingleInstance();

            //// Build the container to finalize registrations
            //// and prepare for object resolution.
            //var container = builder.Build();

            //// Now you can resolve services using Autofac. For example,
            //// this line will execute the lambda expression registered
            //// to the IConfigReader service.
            //using (var scope = container.BeginLifetimeScope())
            //{
            //    var reader = scope.Resolve<WebApp.Models.ICustomerRepository>();
            //}

        }
    }
}
