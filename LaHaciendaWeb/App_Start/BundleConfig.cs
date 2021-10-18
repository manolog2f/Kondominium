﻿using System.Web;
using System.Web.Optimization;

namespace LaHaciendaWeb
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*",
                "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/jquery.unobtrusive-ajax.js",
                "~/Scripts/respond.js",
                "~/Scripts/jquery.form.js",
                "~/Scripts/chosen.jquery.min.js"
            ));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"
            ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/popper.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js",
                "~/Scripts/shieldui-all.min.js",
                "~/Scripts/viewer.js",
                "~/Scripts/jquery.multiselect.js",
                "~/Scripts/Chart.js",
                "~/Scripts/chartjs-plugin-datalabels.js",
                "~/Scripts/app.js"
            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/menu.css",
                "~/Content/all.css",
                "~/Content/tree.min.css",
                "~/Content/jquery-ui.css",
                "~/Content/viewer.css",
                "~/Content/jquery.multiselect.css",
                "~/Content/Chart.css",
                "~/Content/Site.css"
            ));
        }
    }
}