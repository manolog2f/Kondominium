using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Kondominium.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index() { return View(); }
        /// <summary>
        /// Generar Un recibo en PDF
        /// </summary>
        /// <param name="VaucherNumber"></param>
        /// <returns></returns>
        public FileResult File(string VaucherNumber) 
        { 
            ReportViewer rv = new Microsoft.Reporting.WebForms.ReportViewer();
 
            var DataSRecibo = new ReportDataSource("Recibo", new Kondominium_BL.ReportData().ReciboDataTable(VaucherNumber));
            var DataSEmpresa = new ReportDataSource("Empresa", new Kondominium_BL.EmpresaDatos().DataTable());

                       
            rv.ProcessingMode = ProcessingMode.Local; 
            rv.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\Recibo.rdlc"; 
            rv.LocalReport.DataSources.Add(DataSRecibo);
            rv.LocalReport.DataSources.Add(DataSEmpresa);

            rv.LocalReport.Refresh();
            
            byte[] streamBytes = null; 
            string mimeType = "";
            string[] streamids = null;
            Warning[] warnings = null;
            string encoding;
            string filenameExtension;
            streamBytes = rv.LocalReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);
            return File(streamBytes, mimeType, string.Concat("Recibo",VaucherNumber,".pdf")); 
        }

        public ActionResult Recibo(string VaucherNumber)
        {
            ReportViewer rv = new Microsoft.Reporting.WebForms.ReportViewer();

            var DataSRecibo = new ReportDataSource("Recibo", new Kondominium_BL.ReportData().Recibo(VaucherNumber));
            var DataSEmpresa = new ReportDataSource("Empresa", new Kondominium_BL.EmpresaDatos().DataTable());

            //var d = new Kondominium_BL.ReportData().ReciboDataTable(VaucherNumber);

            rv.SizeToReportContent = true;
            //rv.Width = Unit.Percentage(900);
            //rv.Height = Unit.Percentage(900);

            rv.ShowToolBar = true;
            rv.ShowPrintButton = true;
            rv.ShowFindControls = true;
            rv.ShowExportControls = true;

            rv.ProcessingMode = ProcessingMode.Local;
            rv.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\bin\Reports\Recibo.rdlc";
            rv.LocalReport.DataSources.Add(DataSRecibo);
            rv.LocalReport.DataSources.Add(DataSEmpresa);


            rv.LocalReport.Refresh();
            ViewBag.ReportViewer = rv;

            return View();
        }

        public ActionResult Pagos(string VaucherNumber)
        {
            ReportViewer rv = new Microsoft.Reporting.WebForms.ReportViewer();

            var DataSPago = new ReportDataSource("Pago", new Kondominium_BL.ReportData().Pagos(VaucherNumber));
            var DataSEmpresa = new ReportDataSource("Empresa", new Kondominium_BL.EmpresaDatos().DataTable());

            //var d = new Kondominium_BL.ReportData().ReciboDataTable(VaucherNumber);

            rv.SizeToReportContent = true;
            //rv.Width = Unit.Percentage(900);
            //rv.Height = Unit.Percentage(900);

            rv.ShowToolBar = true;
            rv.ShowPrintButton = true;
            rv.ShowFindControls = true;
            rv.ShowExportControls = true;

            rv.ProcessingMode = ProcessingMode.Local;
            rv.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\bin\Reports\Pago.rdlc";
            rv.LocalReport.DataSources.Add(DataSPago);
            rv.LocalReport.DataSources.Add(DataSEmpresa);


            rv.LocalReport.Refresh();
            ViewBag.ReportViewer = rv;

            return View();
        }

        public ActionResult BalanceCondomino(int Id)
        {
            ReportViewer rv = new Microsoft.Reporting.WebForms.ReportViewer();

            var balance = new Kondominium_BL.BalanceDatos().ByCliente(Id);
            var DataSBalance = new ReportDataSource("Balance", balance);
            var DataSEmpresa = new ReportDataSource("Empresa", new Kondominium_BL.EmpresaDatos().DataTable());
            var DataSCliente = new ReportDataSource("Clientes", new Kondominium_BL.ClientesDatos().DataTable(Id));
            var tTotales = new DataTable();

            var tRecibo = balance.Where(x => x.Estado == "Contabilizado").Sum(x => x.TotRecibo);
            var tPago = balance.Where(x => x.Estado == "Contabilizado").Sum(x => x.TotPago);
            var tTotal = tRecibo - tPago;

            tTotales.Columns.Add("TotRecibos");
            tTotales.Columns.Add("TotPagos");
            tTotales.Columns.Add("TotBalance");
            tTotales.Rows.Add(tRecibo, tPago, tTotal);


            var DataSTotales = new ReportDataSource("Totales", tTotales);


            rv.SizeToReportContent = true;
            //rv.Width = Unit.Percentage(900);
            //rv.Height = Unit.Percentage(900);

            rv.ShowToolBar = true;
            rv.ShowPrintButton = true;
            rv.ShowFindControls = true;
            rv.ShowExportControls = true;

            rv.ProcessingMode = ProcessingMode.Local;
            rv.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\bin\Reports\BalanceCliente.rdlc";
            rv.LocalReport.DataSources.Add(DataSBalance);
            rv.LocalReport.DataSources.Add(DataSEmpresa);
            rv.LocalReport.DataSources.Add(DataSCliente);
            rv.LocalReport.DataSources.Add(DataSTotales);


            rv.LocalReport.Refresh();
            ViewBag.ReportViewer = rv;

            return View("View", rv);
        }

        public ActionResult BalancePropiedad(int Id)
        {
            ReportViewer rv = new Microsoft.Reporting.WebForms.ReportViewer();

            var balance = new Kondominium_BL.BalanceDatos().ByPropiedad(Id);
            var DataSBalance = new ReportDataSource("Balance", balance);
            var DataSEmpresa = new ReportDataSource("Empresa", new Kondominium_BL.EmpresaDatos().DataTable());
            var DataSPropiedad = new ReportDataSource("Propiedades", new Kondominium_BL.PropiedadesDatos().DataTable(Id));
            var tTotales = new DataTable();

            var tRecibo = balance.Where(x => x.Estado == "Contabilizado").Sum(x => x.TotRecibo);
            var tPago = balance.Where(x => x.Estado == "Contabilizado").Sum(x => x.TotPago);
            var tTotal = tRecibo - tPago;

            tTotales.Columns.Add("TotRecibos");
            tTotales.Columns.Add("TotPagos");
            tTotales.Columns.Add("TotBalance");
            tTotales.Rows.Add(tRecibo, tPago, tTotal);


            var DataSTotales = new ReportDataSource("Totales", tTotales);


            rv.SizeToReportContent = true;
            //rv.Width = Unit.Percentage(900);
            //rv.Height = Unit.Percentage(900);

            rv.ShowToolBar = true;
            rv.ShowPrintButton = true;
            rv.ShowFindControls = true;
            rv.ShowExportControls = true;

            rv.ProcessingMode = ProcessingMode.Local;
            rv.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\bin\Reports\BalancePropiedad.rdlc";
            rv.LocalReport.DataSources.Add(DataSBalance);
            rv.LocalReport.DataSources.Add(DataSEmpresa);
            rv.LocalReport.DataSources.Add(DataSPropiedad);
            rv.LocalReport.DataSources.Add(DataSTotales);


            rv.LocalReport.Refresh();
            ViewBag.ReportViewer = rv;

            return View("View", rv);
        }


        public ActionResult View(ReportViewer rv)
        {

            ViewBag.ReportViewer = rv;
            return View();
        }

        public ActionResult ASPXView() {
            return View();
        }
        public ActionResult ASPXUserControl() { 
            return View(); 
        }

      
    }
}