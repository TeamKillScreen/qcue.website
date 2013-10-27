using System.Web;
using System.Web.Optimization;

namespace QCue.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // App bundle with no default minify.
            var appBundle = new ScriptBundle("~/bundles/app").Include(
                      "~/Scripts/app.js",
                      "~/Controllers/*.js",
                      "~/Controllers/Shared/*.js",
                      "~/Scripts/dateformat.js");

            appBundle.Transforms.Clear();
            bundles.Add(appBundle);

            // Admin bundle with no default minify.
            var adminBundle = new ScriptBundle("~/bundles/admin").Include(
                      "~/Scripts/admin.js",
                      "~/Controllers/admin/*.js",
                      "~/Controllers/Shared/*.js");

            adminBundle.Transforms.Clear();
            bundles.Add(adminBundle);
        }
    }
}
