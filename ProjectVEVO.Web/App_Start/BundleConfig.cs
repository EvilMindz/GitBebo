using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Optimization;

namespace ProjectVEVO.Web
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
                "~/Scripts/app/vevo.js",
                "~/Scripts/app/factory.js",
                "~/Scripts/app/main.js"
                ));

        }
    }
}