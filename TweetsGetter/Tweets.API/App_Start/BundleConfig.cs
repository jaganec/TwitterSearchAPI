using System.Web;
using System.Web.Optimization;

namespace Tweets.API
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.min.js",
                        "~/Scripts/angular-route.min.js",
                        "~/Scripts/angular-storage.min.js",
                        "~/Scripts/angular-jwt.min.js",
                        "~/Scripts/lock-7.min.js",
                        "~/Scripts/auth0-angular-4.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/appcode").Include(
                "~/JS/config.js",
                        "~/JS/app.js",
                        "~/JS/controllers/TweetsController.js",
                        "~/JS/controllers/LoginController.js",
                        "~/JS/services/TweetData.js"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css")
                      .Include("~/Content/site.css"));
        }
    }
}
