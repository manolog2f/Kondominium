using Kondominium.Utilities;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.text.html.simpleparser;
using HtmlAgilityPack;
using System.Text;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace Kondominium.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        { return View(); }

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
            return File(streamBytes, mimeType, string.Concat("Recibo", VaucherNumber, ".pdf"));
        }

        [HttpGet]
        public ActionResult Recibo(string VaucherNumber)
        {
            //ReportViewer rv = new Microsoft.Reporting.WebForms.ReportViewer();

            //var DataSRecibo = new ReportDataSource("Recibo", new Kondominium_BL.ReportData().Recibo(VaucherNumber));
            //var DataSEmpresa = new ReportDataSource("Empresa", new Kondominium_BL.EmpresaDatos().DataTable());

            ////var d = new Kondominium_BL.ReportData().ReciboDataTable(VaucherNumber);

            //rv.SizeToReportContent = true;
            ////rv.Width = Unit.Percentage(900);
            ////rv.Height = Unit.Percentage(900);

            //rv.ShowToolBar = true;
            //rv.ShowPrintButton = true;
            //rv.ShowFindControls = true;
            //rv.ShowExportControls = true;

            //rv.ProcessingMode = ProcessingMode.Local;

            //rv.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\bin\Reports\Recibo.rdlc";
            //rv.LocalReport.DataSources.Add(DataSRecibo);
            //rv.LocalReport.DataSources.Add(DataSEmpresa);

            //rv.LocalReport.Refresh();
            //ViewBag.ReportViewer = rv;

            return View();
        }

        [HttpGet]
        public ActionResult BalancePropiedad(int PropiedadId)
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public FileResult Export(string GridHtml, String DocName)
        {
            //var Renderer = new IronPdf.ChromePdfRenderer();
            //using var PDF = Renderer.RenderHtmlAsPdf("<h1>Hello IronPdf</h1>");
            //var OutputPath = "pixel-perfect.pdf";
            //PDF.SaveAs(OutputPath);

            HtmlNode.ElementsFlags["img"] = HtmlElementFlag.Closed;
            HtmlNode.ElementsFlags["input"] = HtmlElementFlag.Closed;
            HtmlNode.ElementsFlags["br"] = HtmlElementFlag.Closed;
            HtmlNode.ElementsFlags["hr"] = HtmlElementFlag.Closed;
            HtmlDocument doc = new HtmlDocument();
            doc.OptionFixNestedTags = true;
            doc.LoadHtml(GridHtml);
            GridHtml = doc.DocumentNode.OuterHtml;

            //StringReader sr = new StringReader(GridHtml.ToString());
            //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            //using (MemoryStream memoryStream = new MemoryStream())
            //{
            //    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
            //    pdfDoc.Open();
            //    XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
            //    //    htmlparser.Parse(sr);
            //    pdfDoc.Close();

            //    byte[] bytes = memoryStream.ToArray();
            //    memoryStream.Close();

            //    return File(memoryStream.ToArray(), "application/pdf", "OrderStatus.pdf");
            //}

            //using (MemoryStream stream = new System.IO.MemoryStream())
            //{
            //    Encoding unicode = Encoding.UTF8;
            //    StringReader sr = new StringReader(GridHtml);
            //    Document pdfDoc = new Document(PageSize.LETTER, 10f, 10f, 100f, 0f);
            //    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
            //    pdfDoc.Open();
            //    XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
            //    pdfDoc.Close();
            //    return File(stream.ToArray(), "application/pdf", "OrderStatus.pdf");
            //}
            try
            {
                #region "PdfGenerator"

                Byte[] res = null;
                using (MemoryStream ms = new MemoryStream())
                {
                    var pdf = PdfGenerator.GeneratePdf(GridHtml, PdfSharp.PageSize.Letter, 10);

                    pdf.Save(ms);
                    res = ms.ToArray();

                    var docPdf = string.IsNullOrEmpty(DocName) ? "Document.pdf" : string.Concat(DocName, ".pdf");
                    return File(res, "application/pdf", docPdf);
                }

                #endregion "PdfGenerator"
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static Byte[] HTMLString(String html)
        {
            Byte[] res = null;
            using (MemoryStream ms = new MemoryStream())
            {
                var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf("text", PdfSharp.PageSize.A4);
                pdf.Save(ms);
                res = ms.ToArray();
            }
            return res;
        }

        [HttpGet]
        public ActionResult ReciboMR(string VaucherNumber)
        {
            var model = new Kondominium_BL.ReportData().Recibo(VaucherNumber);

            return View(model);
        }

        [HttpGet]
        public ActionResult BalancePropiedadMR(int PropiedadId)
        {
            var model = new Kondominium_BL.BalanceDatos().ByPropiedad(PropiedadId);

            return View(model);
        }

        public ActionResult ReciboEmail(string VaucherNumber)
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

            /***********/

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;
            byte[] reportByte = rv.LocalReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);
            //string FilePath = Server.MapPath("/data/");
            //FilePath += "ReportName.pdf";
            //using (FileStream fs = new FileStream(FilePath, FileMode.Create))
            //{
            //    fs.Write(bytes, 0, bytes.Length);
            //}

            // Enviar Correo a usuario Indicado

            List<byte[]> adjuntoPDF = new List<byte[]>();

            adjuntoPDF.Add(reportByte);

            var sendmail = new ZTAdminBL.Utilities.Email().sendMAil(new ZTAdminEntities.Utilities.MailEntity
            {
                Body = "Se adjunta Recibo",
                Attachment = adjuntoPDF,
                From = Core.FromEmail,
                Pass = Core.PassEmail,
                Server = Core.SMTServer,
                Port = int.Parse(Core.PortSMTP),
                UserId = Core.UserEmail,
                IncludeAttachment = true,
                To = new string[] { "mramos@zmt-dev.com" },
                Html = true,
                Subject = "Recibo"
            });

            /***********/

            //rv.LocalReport.Refresh();
            //ViewBag.ReportViewer = rv;

            return View();
        }

        //public ActionResult Pagos(string VaucherNumber)
        //{
        //    ReportViewer rv = new Microsoft.Reporting.WebForms.ReportViewer();

        //    var DataSPago = new ReportDataSource("Pago", new Kondominium_BL.ReportData().Pagos(VaucherNumber));
        //    var DataSEmpresa = new ReportDataSource("Empresa", new Kondominium_BL.EmpresaDatos().DataTable());

        //    //var d = new Kondominium_BL.ReportData().ReciboDataTable(VaucherNumber);

        //    rv.SizeToReportContent = true;
        //    //rv.Width = Unit.Percentage(900);
        //    //rv.Height = Unit.Percentage(900);

        //    rv.ShowToolBar = true;
        //    rv.ShowPrintButton = true;
        //    rv.ShowFindControls = true;
        //    rv.ShowExportControls = true;

        //    rv.ProcessingMode = ProcessingMode.Local;
        //    rv.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\bin\Reports\Pago.rdlc";
        //    rv.LocalReport.DataSources.Add(DataSPago);
        //    rv.LocalReport.DataSources.Add(DataSEmpresa);

        //    rv.LocalReport.Refresh();
        //    ViewBag.ReportViewer = rv;

        //    return View();
        //}

        [HttpGet]
        public ActionResult Pagos(string VaucherNumber)
        {
            return View();
        }

        [HttpGet]
        public ActionResult _PagosMR(string VaucherNumber)
        {
            var model = new Kondominium_BL.ReportData().Pagos(VaucherNumber);

            return View(model);
        }

        [HttpGet]
        public ActionResult DetalleDePagos()
        {
            var model = new Kondominium_BL.DetalledePagoDatos().Ejecutar(DateTime.Now, DateTime.Now);

            return View(model);
        }

        [HttpPost]
        public ActionResult DetalleDePagos(string FromDate, string ToDate)
        {
            var model = new Kondominium_BL.DetalledePagoDatos().Ejecutar(DateTime.Parse(FromDate), DateTime.Parse(ToDate));

            return View(model);
        }

        //[HttpGet]
        //public ActionResult _DetalleDePagosMR(string Desde, string Hasta)
        //{
        //}

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

        //public ActionResult BalancePropiedad(int Id)
        //{
        //    ReportViewer rv = new Microsoft.Reporting.WebForms.ReportViewer();

        //    var balance = new Kondominium_BL.BalanceDatos().ByPropiedad(Id);
        //    var DataSBalance = new ReportDataSource("Balance", balance);
        //    var DataSEmpresa = new ReportDataSource("Empresa", new Kondominium_BL.EmpresaDatos().DataTable());
        //    var DataSPropiedad = new ReportDataSource("Propiedades", new Kondominium_BL.PropiedadesDatos().DataTable(Id));
        //    var tTotales = new DataTable();

        //    var tRecibo = balance.Where(x => x.Estado == "Contabilizado").Sum(x => x.TotRecibo);
        //    var tPago = balance.Where(x => x.Estado == "Contabilizado").Sum(x => x.TotPago);
        //    var tTotal = tRecibo - tPago;

        //    tTotales.Columns.Add("TotRecibos");
        //    tTotales.Columns.Add("TotPagos");
        //    tTotales.Columns.Add("TotBalance");
        //    tTotales.Rows.Add(tRecibo, tPago, tTotal);

        //    var DataSTotales = new ReportDataSource("Totales", tTotales);

        //    rv.SizeToReportContent = true;
        //    //rv.Width = Unit.Percentage(900);
        //    //rv.Height = Unit.Percentage(900);

        //    rv.ShowToolBar = true;
        //    rv.ShowPrintButton = true;
        //    rv.ShowFindControls = true;
        //    rv.ShowExportControls = true;

        //    rv.ProcessingMode = ProcessingMode.Local;
        //    rv.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\bin\Reports\BalancePropiedad.rdlc";
        //    rv.LocalReport.DataSources.Add(DataSBalance);
        //    rv.LocalReport.DataSources.Add(DataSEmpresa);
        //    rv.LocalReport.DataSources.Add(DataSPropiedad);
        //    rv.LocalReport.DataSources.Add(DataSTotales);

        //    rv.LocalReport.Refresh();
        //    ViewBag.ReportViewer = rv;

        //    return View("View", rv);
        //}

        public ActionResult View(ReportViewer rv)
        {
            ViewBag.ReportViewer = rv;
            return View();
        }

        public ActionResult ASPXView()
        {
            return View();
        }

        public ActionResult ASPXUserControl()
        {
            return View();
        }
    }
}