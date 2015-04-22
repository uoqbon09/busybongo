using System.Web.Optimization;

namespace BusyBongo.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/libs")
                //.Include("~/Scripts/jquery-{version}.js")                
                //.Include("~/Scripts/knockout-{version}.js")
                //.Include("~/Scripts/bootstrap.js")
                .Include("~/Scripts/Stashy.js")
                );            

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/site.css")
                .Include("~/Content/durandal.css")
                );
        }
    }
}