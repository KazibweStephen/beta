using System.Web.Optimization;

namespace WebUI.App_Start
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            /**
             *  Scripts Section
             */
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.10.2.*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js"));

            //bundles.Add(new ScriptBundle("~/bundles/common").Include(
            //            "~/Scripts/tour.js",
            //            "~/Scripts/common.min.js"));

            //bundles.Add(new ScriptBundle("~/bundles/DataTables").Include(
            //            "~/Scripts/DataTables-1.10.2/jquery.dataTables.*"));

            bundles.Add(new ScriptBundle("~/bundles/SmartWizard").Include(
                        "~/Scripts/jquery.smartWizard-2.0.*"));

            bundles.Add(new ScriptBundle("~/bundles/BootstrapDatepicker").Include(
                        "~/Scripts/bootstrap-datepicker.js"));

            /**
             * Styles Section
             * 
             */

            bundles.Add(new StyleBundle("~/Content/FontAwesome").Include(
                        "~/Content/font-awesome.*"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                        "~/Content/bootstrap.*"));

            bundles.Add(new StyleBundle("~/Content/main").Include(
                        "~/Content/main.css"));

            //bundles.Add(new StyleBundle("~/Content/DataTables").Include(
            //            "~/Content/DataTables-1.10.2/css/jquery.*"));

            bundles.Add(new StyleBundle("~/Content/SmartWizard").Include(
                        "~/Content/smart_wizard.css"));

            bundles.Add(new StyleBundle("~/Content/BootstrapDatepicker").Include(
                        "~/Content/bootstrap-datepicker3.css"));
            bundles.Add(new StyleBundle("~/Content/AdminCss").Include(
                   "~/Content/bootstrapcss/bootstrap.min.css"
                   ).Include("~/Content/font-awesome/css/font-awesome.min.css")
                   .Include("~/Content/css/local.css"));
          
 



            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
