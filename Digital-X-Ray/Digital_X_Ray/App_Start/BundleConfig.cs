using System.Web;
using System.Web.Optimization;

namespace Digital_X_Ray
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {          
            
            // Bootstrap CSS y JS
            bundles.Add(new StyleBundle("~/Bootstrap/Styles").Include(
                      "~/Content/bootstrap-4.0.0-beta/dist/css/bootstrap.min.css",
                      "~/Content/bootstrap-4.0.0-beta/dist/css/bootstrap-grid.min.css",
                      "~/Content/bootstrap-4.0.0-beta/dist/css/bootstrap-reboot.min.css"
                ));

            bundles.Add(new ScriptBundle("~/Bootstrap/Scripts").Include(
                      "~/Content/bootstrap-4.0.0-beta/assets/js/vendor/popper.min.js",
                      "~/Content/bootstrap-4.0.0-beta/dist/js/bootstrap.min.js"
                ));



            // DataTables Plugin CSS y JS
            bundles.Add(new StyleBundle("~/DataTables/Styles").Include(
                    "~/Content/DataTables-1.10.16/css/dataTables.bootstrap4.min.js"
                ));

            bundles.Add(new ScriptBundle("~/DataTables/Scripts").Include(
                    "~/Content/DataTables-1.10.16/js/jquery.dataTables.min.js",
                    "~/Content/DataTables-1.10.16/js/dataTables.bootstrap4.min.js"
                ));

            
            //Extras
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                      "~/Scripts/jquery-3.2.1.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryVal").Include(
                      "~/Scripts/jquery.validate.min.js"
                ));

            bundles.Add(new ScriptBundle("~/Project/Methods").Include(
                    "~/Scripts/methods/mainQuery.js",
                    "~/Scripts/methods/modifyClass.js"
                ));

        }
    }
}
