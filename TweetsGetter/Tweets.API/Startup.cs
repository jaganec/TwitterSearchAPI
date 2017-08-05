using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using Tweets.API;

[assembly: OwinStartup(typeof(Startup))]
namespace Tweets.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           

            ConfigureAuthZero(app);
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);        
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }
    }
}