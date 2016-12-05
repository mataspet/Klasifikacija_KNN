using System.Web;
using System.Web.Optimization;

namespace Klasifikacija_KNN
{
    public static class BundleConfig
    {
        public static void PostStart()
        {
            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/semantic").
			   Include("~/Scripts/jquery-{version}.js", "~/Scripts/semantic.js"));
			   
            BundleTable.Bundles.Add(new StyleBundle("~/Content/semantic").
			   Include("~/Content/semantic.css"));
        }
    }
}