using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Mvc;
using Tweets.API.App_Start;
using Tweets.API.Configuration;
using System.Web.Http.Cors;
using Tweets.API.Helpers;

namespace Tweets.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<ITweetConfig, TweetConfig>(new HierarchicalLifetimeManager());
            container.RegisterType<IGetTweets, GetTweets>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
          
            // Web API configuration and services

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
