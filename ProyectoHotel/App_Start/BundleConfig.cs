using ProyectoHotel.Configuracion;
using System.Web;
using System.Web.Optimization;

namespace ProyectoHotel
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            var bundleScript = new ScriptBundle("~/bundles/bootstrap")
           .Include("~/vendor/jquery/jquery.min.js")
           .Include("~/vendor/bootstrap/js/bootstrap.bundle.js")
           .Include("~/vendor/jquery-easing/jquery.easing.min.js")
           .Include("~/js/sb-admin-2.min.js")
           .Include("~/vendor/datatables/jquery.dataTables.min.js")
           .Include("~/vendor/datatables/dataTables.bootstrap4.min.js")
           .Include("~/Scripts/SweetAlert/sweetalert.min.js")
           .Include("~/Scripts/jquery-ui.js")
           .Include("~/Scripts/Configuracion.js");



            bundleScript.Orderer = new AsIsBundleOrderer();

            bundles.Add(bundleScript);



            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/css/sb-admin-2.min.css",
                      "~/vendor/fontawesome-free/css/all.min.css",
                      "~/vendor/datatables/dataTables.bootstrap4.min.css",
                      "~/Content/jquery-ui.css"
                      ));

        }
    }
}
