using System.Web.Optimization;

namespace Integra.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-migrate-{version}.js"));

            bundles.Add(new ScriptBundle("~/dataTables").Include(
                        "~/Scripts/jquery.dataTables.js",
                        "~/Scripts/jquery.dataTables.plugins.js",
                        "~/Scripts/AutoFill.js",
                        "~/Scripts/knockout-datatables.js",
                        "~/Scripts/ZeroClipboard.js"
                        ));

            bundles.Add(new ScriptBundle("~/jsValidate").Include(
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/additional-methods.js",
                        "~/scripts/jquery.validate.unobtrusive-{version}.js",
                        "~/Scripts/jquery.validate.unobtrusive-custom-for-bootstrap.js",
                        "~/Scripts/accounting-{version}.js",
                        "~/Scripts/bootstrap.js"));

            bundles.Add(new Bundle("~/jsMasks").Include(
                        "~/Scripts/jquery.maskedinput-{version}.js",
                        "~/Scripts/jquery.maskMoney.js",
                        "~/Scripts/jquery.fileDownload.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                        "~/Scripts/knockout-{version}.js",
                        "~/Scripts/knockout.validation.js",
                        "~/Scripts/knockout-jqueryui-{version}.js",
                        "~/Scripts/knockout.pt-BR.js",
                        "~/Scripts/Config.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/content/css").Include(
                        "~/Content/body.css",
                        "~/Content/bootstrap.css",
                        "~/Content/bootstrap-responsive.css",
                        "~/Content/bootstrap-mvc-validation.css",
                        "~/Content/layout-inicio.css",
                        "~/Content/layout-datatable.css"
                        ));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
            //BundleTable.EnableOptimizations = true;

            bundles.Add(new ScriptBundle("~/BlockUI").Include(
                        "~/Scripts/jquery.blockUI.js",
                        "~/Scripts/Mensagem.js",
                        "~/Scripts/Funcoes.js"));

            bundles.Add(new StyleBundle("~/BlockUIcss").Include(
                        "~/Content/LoadWindows8.css"));

            bundles.Add(new ScriptBundle("~/canvg").Include(
                        "~/Scripts/rgbcolor.js",
                        "~/Scripts/StackBlur.js",
                        "~/Scripts/canvg.js"));
        }
    }
}