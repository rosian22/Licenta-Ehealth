﻿using System.Web;
using System.Web.Optimization;

namespace EHealth
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            bundles.Add(new ScriptBundle("~/bundles/semantic-component").Include(
                      "~/Scripts/semantic.min.js",
                      "~/Scripts/popup.min.js",
                      "~/Scripts/dropdown.min.js",
                      "~/Scripts/modal.min.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/semantic-component").Include(
                      "~/Content/semantic.min.css",
                      "~/Content/popup.min.css",
                      "~/Content/progress.min.css",
                      "~/Content/message.min.css",
                      "~/Content/modal.min.css",
                      "~/Content/table.min.css",
                      "~/Content/dropdown.min.css",
                      "~/Content/menu.min.css"));

        }
    }
}
