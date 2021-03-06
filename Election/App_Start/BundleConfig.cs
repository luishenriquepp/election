﻿using System.Web;
using System.Web.Optimization;

namespace Election
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-route.js",
                        "~/Scripts/angular-local-storage.js",
                        "~/AngularApp/main.js",
                        "~/AngularApp/config.js"));

            bundles.Add(new ScriptBundle("~/bundles/factories").Include(
                    "~/AngularApp/Factories/restaurant.js",
                    "~/AngularApp/Factories/poll.js",
                    "~/AngularApp/Factories/vote.js",
                    "~/AngularApp/Factories/login.js"));

            bundles.Add(new ScriptBundle("~/bundles/controllers").Include(
                    "~/AngularApp/Controllers/restaurant.js",
                    "~/AngularApp/Controllers/poll.js",
                    "~/AngularApp/Controllers/vote.js",
                    "~/AngularApp/Controllers/login.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/angular-csp.css"));
        }
    }
}
