using System.Web;
using System.Web.Optimization;

namespace AdminPortal
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

            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                        "~/Scripts/moment.js",
                         "~/Scripts/moment.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(

                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/bootstrap-timepicker.js",
                      "~/Scripts/bootstrap-timepicker.min.js",
                      "~/Scripts/bootstrap-datetimepicker.js",
                      "~/Scripts/bootstrap-datetimepicker.min.js"
                      
                      ));

            bundles.Add(new ScriptBundle("~/bundles/rencurrenceTypeController").Include(
                     "~/Scripts/rencurrenceTypeController.js"
                     ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/bootstrap.theme.css",
                      "~/Content/bootstrap.timepicker.css",
                      "~/Content/bootstrap.timepicker.min.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/bootstrap.datetimepicker-build.less",
                      "~/Content/bootstrap.theem.min.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                    "~/Scripts/knockout-{version}.js",
                    "~/Scripts/app.js",
                    "~/Scripts/metisMenu.js"));

            bundles.Add(new ScriptBundle("~/bundles/metisMenu").Include(
                        "~/Scripts/metisMenu.js"));


        }
    }
}
