using System.IO;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClosedXML.Excel;

namespace Kondominium.Controllers
{
    public class QueryController : Controller
    {
        // GET: Query
        public ActionResult Index()
        {
            return View();
        }

        //public FileResult Export(DataTable tabla)
        //{
 

        //    --var dTabla = ZoomTechUtils.ZMTDriveDataTable.ToDataTable(new Kondominium_BL.CuentasPorCobrarPagoDatos().GetAll());

        //    using (XLWorkbook wb = new XLWorkbook())
        //    {
        //        wb.Worksheets.Add(tabla, "Reporte");
        //        using (MemoryStream stream = new MemoryStream())
        //        {
        //            wb.SaveAs(stream);
        //            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
        //        }
        //    }
        //}

    }
}