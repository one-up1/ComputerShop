using ComputerShop.Data.Models;
using ComputerShop.Data.Services;
using System.Web.Mvc;

namespace ComputerShop.Web.Controllers
{
    public class RepairPartsController : Controller
    {
        private readonly IShopData db;

        public RepairPartsController(IShopData db)
        {
            this.db = db;
        }

        // GET: RepairParts
        public ActionResult Index(int id)
        {
            var model = db.GetRepairParts(id);
            return View(model);
        }
    }
}