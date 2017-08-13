using System.Web;
using System.Web.Optimization;

namespace sifayco
{
    public class BundleConfig
    {
        // Para obtener más información acerca de Bundling, consulte http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/vendors/jquery-min").Include("~/Vendors/jquery/dist/jquery-2.*"));
            bundles.Add(new ScriptBundle("~/vendors/bootstrap-min").Include("~/Vendors/bootstrap-3.3.7-dist/js/bootstrap-min.js"));
            bundles.Add(new ScriptBundle("~/vendors/fastclick").Include("~/Vendors/fastclick/lib/fastclick.js"));
            bundles.Add(new ScriptBundle("~/vendors/nprogress").Include("~/Vendors/nprogress/nprogress.js"));
            bundles.Add(new ScriptBundle("~/vendors/custom-min").Include("~/Build/js/custom-min.js"));

            bundles.Add(new ScriptBundle("~/vendors/raphael-min").Include("~/Vendors/raphael/raphael-min.js"));
            bundles.Add(new ScriptBundle("~/vendors/morris-min").Include("~/Vendors/morris/morris-min.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include("~/Scripts/jquery-ui-{version}.js"));
            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.unobtrusive*","~/Scripts/jquery.validate*"));
            
            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información sobre los formularios. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de creación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

            //bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));
            bundles.Add(new StyleBundle("~/vendors/bootstrap/css").Include("~/Vendors/bootstrap-3.3.7-dist/css/bootstrap-min.css"));
            bundles.Add(new StyleBundle("~/vendors/nprogress/css").Include("~/Vendors/nprogress/nprogress.css"));
            bundles.Add(new StyleBundle("~/vendors/custom-min/css").Include("~/Build/css/custom-min.css"));
            bundles.Add(new StyleBundle("~/vendors/font-awesome-min/css").Include("~/Vendors/font-awesome/css/font-awesome-min.css"));
            bundles.Add(new StyleBundle("~/vendors/iCheck/css").Include("~/Vendors/iCheck/skins/flat/green.css"));
        }
    }
}