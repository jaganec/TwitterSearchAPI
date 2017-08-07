using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using System.Net.Http.Headers;
using System.Web.Http;
using Tweets.API.App_Start;
using Tweets.API.Configuration;
using System.Web.Http.Cors;
using Tweets.API.Helpers;
using System.Configuration;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Tweets.App_Start;

namespace Tweets.App_Start
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
            var clientID = ConfigurationManager.AppSettings["auth0:ClientId"];
            var issuer = "https://" + ConfigurationManager.AppSettings["auth0:Domain"] + "/";
            var clientSecret = TextEncodings.Base64.Encode(TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["auth0:ClientSecret"]));

            config.MessageHandlers.Add(new JsonWebTokenValidationHandler()
            {
                Audience = clientID,
                SymmetricKey = clientSecret,
                IsSecretBase64Encoded =false
            });
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
