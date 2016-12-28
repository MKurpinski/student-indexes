using System.Linq;
using System.Web.Http;
using Microsoft.Practices.Unity;
using StudentIndexes.Domain.Repositories;
using StudentIndexes.Domain.Repositories.Interfaces;

namespace StudentIndexes.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            var container = new UnityContainer();
            container.RegisterType<IStudentRepository, StudentRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IAuthRepository, AuthRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
            var jsonFormatter = config.Formatters.OfType<System.Net.Http.Formatting.JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
        }
    }
}
