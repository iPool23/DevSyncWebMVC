using System.Web;
using System.Web.Optimization;

namespace Presentacion
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/complementos").Include(
                "~/Scripts/fontawesome/all.min.js",
                "~/Scripts/script.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/Style.css"));
        }
    }
}