using System.Web.Optimization;

namespace ProjectBebo.Web
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            
            bundles.Add(new StyleBundle("~/Content/css").Include(                
                "~/Content/bootstrap.min.css",
                "~/Content/bootstrap-theme.min.css",
                "~/Content/app/main.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Scripts/jquery-{version}.min.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/app/Bebo.js",
                "~/Scripts/app/factory.js",
                "~/Scripts/app/main.js"
                ));

        }
    }
}