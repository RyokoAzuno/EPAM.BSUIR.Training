using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace Books.WebApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "GetAPI",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { controller = "Book", action = "GetAllBooks", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "AddAPI",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { controller = "Book", action = "AddBook", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "GetSingleAPI",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { controller = "Book", action = "GetBook", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "UpdateAPI",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { controller = "Book", action = "UpdateBook", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DeleteAPI",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { controller = "Book", action = "DeleteBook", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
