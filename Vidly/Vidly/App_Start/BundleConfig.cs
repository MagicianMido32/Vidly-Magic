using System.Web.Optimization;

namespace Vidly
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //we merged Jquery bundle with bootstrap bundle and called it lib
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        //bootbox for box notification
                        "~/Scripts/bootbox.js",
                       //datatables scripts
                       "~/scripts/datatables/jquery.datatables.js",
                       "~/scripts/datatables/jquery.bootstrap.js",
                       //there's a problem with the look of the previous and next button as well as the show dropdown
                       //might wanna add a bootstrap class to it with javascript
                       "~/scripts/fixDataTablesMine.js",
                        //type ahead
                        "~/scripts/typeahead.bundle.js",
                        //toastr makes toast
                        "~/scripts/toastr.js"
                        ));

            //JQuery validation
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      // "~/Content/bootstrap.css",
                      "~/Content/bootstrap-lumen.css",
                      //data tables
                      "~/Content/datatables/css/datatables.bootstrap.css",
                      // "~/Content/datatables/css/jquery.dataTables.css",
                      "~/Content/typeahead.css",
                      "~/Content/toastr.css",
                      "~/Content/bootstrap-mytheme.css",
                      "~/Content/site.css"

                      ));

            //fontawesome
            bundles.Add(new ScriptBundle("~/bundles/fontawesome")
                .Include("~/Content/fontawesome/js/all.js"));
            bundles.Add(new StyleBundle("~/Content/fontawesome")
                .Include("~/Content/fontawesome/css/all.css"));

            //homepage
            bundles.Add(new StyleBundle("~/Content/homepage")
                .Include("~/Content/homepage.css"));
        }
    }
}