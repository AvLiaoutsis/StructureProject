using System.Web;
using System.Web.Optimization;

namespace StructureProject
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootbox.js",
                        "~/Scripts/datatables/jquery.datatables.js",
                       "~/Scripts/datatables/datatables.bootstrap.js",
                       "~/Scripts/moment.min.js",
                       "~/Scripts/bootstrap-datetimepicker.js",
                       "~/Scripts/fontawesome/all.min.js",
                       "~/Scripts/toastr.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/registerjs").Include(
            "~/Scripts/Register/additional-methods.min.js",
            "~/Scripts/Register/jquery.steps.min.js",
            "~/Scripts/Register/jquery.validate.min.js",
            "~/Scripts/Register/register.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-theme-united.css",
                      "~/Content/datatables/css/datatables.bootstrap.css",
                      "~/Content/toastr.css",
                      "~/Content/bootstrap-datetimepicker.css",
                      "~/Content/fontawesome-all.css",
                      "~/Content/Site.css"));


            bundles.Add(new StyleBundle("~/Content/css4").Include(
              "~/Content/bootstrap4",
              "~/Content/datatables/css/datatables.bootstrap.css",
              "~/Content/toastr.css",
              "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/registerCSS").Include(
                    "~/Content/Register/material-design-iconic-font.min.css",
                    "~/Content/Register/registerStyle.css"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap4").Include(
             "~/Scripts/bootstrap.js"));
        }
    }
}
