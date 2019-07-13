using System.Web;
using System.Web.Optimization;

namespace Cube.Mlm
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region SCRIPTS

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/toastrModule").Include(
                        "~/Scripts/jquery.notifyBar.js",
                        "~/Scripts/toastrModule.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                        "~/Scripts/knockout-3.4.2.js"));

            bundles.Add(new ScriptBundle("~/bundles/loginModule").Include(
                        "~/Scripts/Modules/loginModule.js"));

            bundles.Add(new ScriptBundle("~/bundles/ajaxhelper").Include(
                        "~/Scripts/common/ajaxHelper.js"));

            bundles.Add(new ScriptBundle("~/bundles/utils").Include(
                        "~/Scripts/common/utils.js"));

            bundles.Add(new ScriptBundle("~/bundles/defs").Include(
                        "~/Scripts/common/defs.js"));

            #endregion


            #region CSS

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/common").Include(
                        "~/Content/css-reset.css",
                        "~/Content/base-theme.css"));

            bundles.Add(new StyleBundle("~/Content/toastrModule").Include(
                        "~/Content/jquery.notifyBar.css"));

            bundles.Add(new StyleBundle("~/Content/login").Include(
                       "~/Content/pages/login.css"));

            bundles.Add(new StyleBundle("~/Content/forgotpassword").Include(
                     "~/Content/pages/forgotpassword.css"));


            #endregion

        }
    }
}
