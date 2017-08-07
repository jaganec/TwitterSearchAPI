using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Cors;
using Tweets.App_Start;
using Microsoft.Practices.Unity.Mvc;

[assembly: OwinStartup(typeof(Startup))]
namespace Tweets.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            // Configure Web API           
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }
    }
}