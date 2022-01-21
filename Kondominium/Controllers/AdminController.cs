using System.Web.Mvc;

namespace Kondominium.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _PartialLeftMenu()
        {
            return PartialView();
        }
    }
}