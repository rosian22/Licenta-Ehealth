﻿// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
// 0114: suppress "Foo.BarController.Baz()' hides inherited member 'Qux.BarController.Baz()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword." when an action (with an argument) overrides an action in a parent controller
#pragma warning disable 1591, 3008, 3009, 0108, 0114
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
public static partial class MVC
{
    public static T4MVC.AccountController Account = new T4MVC.AccountController();
    public static T4MVC.EmailsController Emails = new T4MVC.EmailsController();
    public static T4MVC.HomeController Home = new T4MVC.HomeController();
    public static T4MVC.ManageController Manage = new T4MVC.ManageController();
    public static T4MVC.SharedController Shared = new T4MVC.SharedController();
}

namespace T4MVC
{
}

#pragma warning disable 0436
namespace T4MVC
{
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class Dummy
    {
        private Dummy() { }
        public static Dummy Instance = new Dummy();
    }
}
#pragma warning restore 0436




namespace Links
{
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public static class Scripts {
        public const string UrlPath = "~/Scripts";
        public static string Url() { return T4MVCHelpers.ProcessVirtualPath(UrlPath); }
        public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(UrlPath + "/" + fileName); }
        public static readonly string bootstrap_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/bootstrap.min.js") ? Url("bootstrap.min.js") : Url("bootstrap.js");
        public static readonly string bootstrap_min_js = Url("bootstrap.min.js");
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class common {
            public const string UrlPath = "~/Scripts/common";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(UrlPath); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(UrlPath + "/" + fileName); }
            public static readonly string ajaxHelper_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/ajaxHelper.min.js") ? Url("ajaxHelper.min.js") : Url("ajaxHelper.js");
            public static readonly string Defs_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/Defs.min.js") ? Url("Defs.min.js") : Url("Defs.js");
            public static readonly string Utils_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/Utils.min.js") ? Url("Utils.min.js") : Url("Utils.js");
        }
    
        public static readonly string jquery_1_10_2_intellisense_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/jquery-1.10.2.intellisense.min.js") ? Url("jquery-1.10.2.intellisense.min.js") : Url("jquery-1.10.2.intellisense.js");
        public static readonly string jquery_1_10_2_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/jquery-1.10.2.min.js") ? Url("jquery-1.10.2.min.js") : Url("jquery-1.10.2.js");
        public static readonly string jquery_1_10_2_min_js = Url("jquery-1.10.2.min.js");
        public static readonly string jquery_1_10_2_min_map = Url("jquery-1.10.2.min.map");
        public static readonly string jquery_notifyBar_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/jquery.notifyBar.min.js") ? Url("jquery.notifyBar.min.js") : Url("jquery.notifyBar.js");
        public static readonly string jquery_validate_vsdoc_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/jquery.validate-vsdoc.min.js") ? Url("jquery.validate-vsdoc.min.js") : Url("jquery.validate-vsdoc.js");
        public static readonly string jquery_validate_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/jquery.validate.min.js") ? Url("jquery.validate.min.js") : Url("jquery.validate.js");
        public static readonly string jquery_validate_min_js = Url("jquery.validate.min.js");
        public static readonly string jquery_validate_unobtrusive_bootstrap_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/jquery.validate.unobtrusive.bootstrap.min.js") ? Url("jquery.validate.unobtrusive.bootstrap.min.js") : Url("jquery.validate.unobtrusive.bootstrap.js");
        public static readonly string jquery_validate_unobtrusive_bootstrap_min_js = Url("jquery.validate.unobtrusive.bootstrap.min.js");
        public static readonly string jquery_validate_unobtrusive_bootstrap_min_js_map = Url("jquery.validate.unobtrusive.bootstrap.min.js.map");
        public static readonly string jquery_validate_unobtrusive_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/jquery.validate.unobtrusive.min.js") ? Url("jquery.validate.unobtrusive.min.js") : Url("jquery.validate.unobtrusive.js");
        public static readonly string jquery_validate_unobtrusive_min_js = Url("jquery.validate.unobtrusive.min.js");
        public static readonly string knockout_3_4_2_debug_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/knockout-3.4.2.debug.min.js") ? Url("knockout-3.4.2.debug.min.js") : Url("knockout-3.4.2.debug.js");
        public static readonly string knockout_3_4_2_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/knockout-3.4.2.min.js") ? Url("knockout-3.4.2.min.js") : Url("knockout-3.4.2.js");
        public static readonly string modernizr_2_6_2_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/modernizr-2.6.2.min.js") ? Url("modernizr-2.6.2.min.js") : Url("modernizr-2.6.2.js");
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class Modules {
            public const string UrlPath = "~/Scripts/Modules";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(UrlPath); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(UrlPath + "/" + fileName); }
            public static readonly string ajaxHelper_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/ajaxHelper.min.js") ? Url("ajaxHelper.min.js") : Url("ajaxHelper.js");
            public static readonly string loginModule_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/loginModule.min.js") ? Url("loginModule.min.js") : Url("loginModule.js");
        }
    
        public static readonly string respond_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/respond.min.js") ? Url("respond.min.js") : Url("respond.js");
        public static readonly string respond_min_js = Url("respond.min.js");
        public static readonly string toastrModule_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/toastrModule.min.js") ? Url("toastrModule.min.js") : Url("toastrModule.js");
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public static class Content {
        public const string UrlPath = "~/Content";
        public static string Url() { return T4MVCHelpers.ProcessVirtualPath(UrlPath); }
        public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(UrlPath + "/" + fileName); }
        public static readonly string base_theme_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/base-theme.min.css") ? Url("base-theme.min.css") : Url("base-theme.css");
        public static readonly string bootstrap_theme_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/bootstrap-theme.min.css") ? Url("bootstrap-theme.min.css") : Url("bootstrap-theme.css");
        public static readonly string bootstrap_theme_min_css = Url("bootstrap-theme.min.css");
        public static readonly string bootstrap_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/bootstrap.min.css") ? Url("bootstrap.min.css") : Url("bootstrap.css");
        public static readonly string bootstrap_min_css = Url("bootstrap.min.css");
        public static readonly string css_reset_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/css-reset.min.css") ? Url("css-reset.min.css") : Url("css-reset.css");
        public static readonly string jquery_notifyBar_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/jquery.notifyBar.min.css") ? Url("jquery.notifyBar.min.css") : Url("jquery.notifyBar.css");
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class pages {
            public const string UrlPath = "~/Content/pages";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(UrlPath); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(UrlPath + "/" + fileName); }
            public static readonly string forgotpassword_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/forgotpassword.min.css") ? Url("forgotpassword.min.css") : Url("forgotpassword.css");
            public static readonly string login_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/login.min.css") ? Url("login.min.css") : Url("login.css");
        }
    
        public static readonly string Site_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/Site.min.css") ? Url("Site.min.css") : Url("Site.css");
    }

    
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public static partial class Bundles
    {
        public static partial class Scripts 
        {
            public static partial class common 
            {
                public static class Assets
                {
                    public static readonly string ajaxHelper_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/common/ajaxHelper.js"); 
                    public static readonly string Defs_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/common/Defs.js"); 
                    public static readonly string Utils_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/common/Utils.js"); 
                }
            }
            public static partial class Modules 
            {
                public static class Assets
                {
                    public static readonly string ajaxHelper_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/Modules/ajaxHelper.js"); 
                    public static readonly string loginModule_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/Modules/loginModule.js"); 
                }
            }
            public static class Assets
            {
                public static readonly string bootstrap_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/bootstrap.js"); 
                public static readonly string bootstrap_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/bootstrap.min.js"); 
                public static readonly string jquery_1_10_2_intellisense_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/jquery-1.10.2.intellisense.js"); 
                public static readonly string jquery_1_10_2_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/jquery-1.10.2.js"); 
                public static readonly string jquery_1_10_2_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/jquery-1.10.2.min.js"); 
                public static readonly string jquery_notifyBar_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/jquery.notifyBar.js"); 
                public static readonly string jquery_validate_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/jquery.validate.js"); 
                public static readonly string jquery_validate_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/jquery.validate.min.js"); 
                public static readonly string jquery_validate_unobtrusive_bootstrap_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/jquery.validate.unobtrusive.bootstrap.js"); 
                public static readonly string jquery_validate_unobtrusive_bootstrap_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/jquery.validate.unobtrusive.bootstrap.min.js"); 
                public static readonly string jquery_validate_unobtrusive_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/jquery.validate.unobtrusive.js"); 
                public static readonly string jquery_validate_unobtrusive_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/jquery.validate.unobtrusive.min.js"); 
                public static readonly string knockout_3_4_2_debug_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/knockout-3.4.2.debug.js"); 
                public static readonly string knockout_3_4_2_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/knockout-3.4.2.js"); 
                public static readonly string modernizr_2_6_2_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/modernizr-2.6.2.js"); 
                public static readonly string respond_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/respond.js"); 
                public static readonly string respond_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/respond.min.js"); 
                public static readonly string toastrModule_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/toastrModule.js"); 
            }
        }
        public static partial class Content 
        {
            public static partial class pages 
            {
                public static class Assets
                {
                    public static readonly string forgotpassword_css = T4MVCHelpers.ProcessAssetPath("~/Content/pages/forgotpassword.css");
                    public static readonly string login_css = T4MVCHelpers.ProcessAssetPath("~/Content/pages/login.css");
                }
            }
            public static class Assets
            {
                public static readonly string base_theme_css = T4MVCHelpers.ProcessAssetPath("~/Content/base-theme.css");
                public static readonly string bootstrap_theme_css = T4MVCHelpers.ProcessAssetPath("~/Content/bootstrap-theme.css");
                public static readonly string bootstrap_theme_min_css = T4MVCHelpers.ProcessAssetPath("~/Content/bootstrap-theme.min.css");
                public static readonly string bootstrap_css = T4MVCHelpers.ProcessAssetPath("~/Content/bootstrap.css");
                public static readonly string bootstrap_min_css = T4MVCHelpers.ProcessAssetPath("~/Content/bootstrap.min.css");
                public static readonly string css_reset_css = T4MVCHelpers.ProcessAssetPath("~/Content/css-reset.css");
                public static readonly string jquery_notifyBar_css = T4MVCHelpers.ProcessAssetPath("~/Content/jquery.notifyBar.css");
                public static readonly string Site_css = T4MVCHelpers.ProcessAssetPath("~/Content/Site.css");
            }
        }
    }
}

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal static class T4MVCHelpers {
    // You can change the ProcessVirtualPath method to modify the path that gets returned to the client.
    // e.g. you can prepend a domain, or append a query string:
    //      return "http://localhost" + path + "?foo=bar";
    private static string ProcessVirtualPathDefault(string virtualPath) {
        // The path that comes in starts with ~/ and must first be made absolute
        string path = VirtualPathUtility.ToAbsolute(virtualPath);
        
        // Add your own modifications here before returning the path
        return path;
    }

    private static string ProcessAssetPathDefault(string virtualPath) {
        // The path that comes in starts with ~/ and should retain this prefix
        return virtualPath;
    }

    // Calling ProcessVirtualPath through delegate to allow it to be replaced for unit testing
    public static Func<string, string> ProcessVirtualPath = ProcessVirtualPathDefault;
    public static Func<string, string> ProcessAssetPath = ProcessAssetPathDefault;

    // Calling T4Extension.TimestampString through delegate to allow it to be replaced for unit testing and other purposes
    public static Func<string, string> TimestampString = System.Web.Mvc.T4Extensions.TimestampString;

    // Logic to determine if the app is running in production or dev environment
    public static bool IsProduction() { 
        return (HttpContext.Current != null && !HttpContext.Current.IsDebuggingEnabled); 
    }
}





#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114


