using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SampleApi.MessageHandlers;

namespace SampleApi
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        private void Configure(HttpConfiguration httpConfiguration)
        {
            httpConfiguration.MessageHandlers.Add(new HtmlMessageHandler());
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "HtmlApiGetAll",
                url: "api/{controller}/{format}",
                constraints: new { format = @"html" },
                defaults: new { controller = "HtmlController", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "HtmlApiGet",
                url: "api/{controller}/{id}/{format}",
                constraints: new { format = @"html" },
                defaults: new { controller = "HtmlController", action = "Get",  id = UrlParameter.Optional }
            );

            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            BundleTable.Bundles.RegisterTemplateBundles();

            Configure(System.Web.Http.GlobalConfiguration.Configuration);
        }
    }
}