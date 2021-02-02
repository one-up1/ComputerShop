using ComputerShop.Data.Services;
using System.Web.Mvc;

namespace ComputerShop.Web.Controllers
{
    public class RepairsController : Controller
    {
        private readonly IRepairData db;

        public RepairsController(IRepairData db)
        {
            this.db = db;
        }

        // GET: Repairs
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }
    }
}