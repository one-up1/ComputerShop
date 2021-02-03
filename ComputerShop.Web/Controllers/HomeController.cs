using ComputerShop.Data.Services;
using System.Web.Mvc;

namespace ComputerShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private IRepairData db;

        public HomeController(IRepairData db)
        {
            this.db = db;
        }

        public ActionResult Index()
        {
            var model = db.GetAll();
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