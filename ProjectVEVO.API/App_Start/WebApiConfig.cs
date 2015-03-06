using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace ProjectBebo.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            var formatters = GlobalConfiguration.Configuration.Formatters;
            formatters.Remove(formatters.XmlFormatter);
            
            config.Routes.MapHttpRoute(
                name: "VideoApi",
                routeTemplate: "api/{controller}/{title}/{description}",
                defaults: new { title = RouteParameter.Optional, description = RouteParameter.Optional, controller = "Video" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );            


            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            //Tracing has been turned off
            //config.EnableSystemDiagnosticsTracing();
        }
    }
}
