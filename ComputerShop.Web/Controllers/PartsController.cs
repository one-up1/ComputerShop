using ComputerShop.Data.Models;
using ComputerShop.Data.Services;
using System.Web.Mvc;

namespace ComputerShop.Web.Controllers
{
    public class PartsController : Controller
    {
        private readonly IShopData db;

        public PartsController(IShopData db)
        {
            this.db = db;
        }

        // GET: Parts
        public ActionResult Index()
        {
            var model = db.GetParts();
            return View(model);
        }
    }
}