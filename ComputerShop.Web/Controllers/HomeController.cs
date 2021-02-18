using ComputerShop.Data.Services;
using System.Web.Mvc;

namespace ComputerShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private IShopData db;

        public HomeController(IShopData db)
        {
            this.db = db;
        }

        public ActionResult Index()
        {
            var model = db.GetRepairs();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "We lossen al uw problemen voor u op";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Neem contact met ons op";

            return View();
        }
    }
}