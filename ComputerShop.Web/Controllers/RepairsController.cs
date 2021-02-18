using ComputerShop.Data.Models;
using ComputerShop.Data.Services;
using System.Web.Mvc;

namespace ComputerShop.Web.Controllers
{
    public class RepairsController : Controller
    {
        private readonly IShopData db;

        public RepairsController(IShopData db)
        {
            this.db = db;
        }

        // GET: Repairs
        public ActionResult Index()
        {
            var model = db.GetRepairs();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = db.GetRepair(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Repair repair)
        {
            if (ModelState.IsValid)
            {
                db.AddRepair(repair);
                return RedirectToAction("Details", new { id = repair.Id });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.GetRepair(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Repair repair)
        {
            if (ModelState.IsValid)
            {
                db.UpdateRepair(repair);
                TempData["Message"] = "Reparatie opgeslagen";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.GetRepair(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.DeleteRepair(id);
            return RedirectToAction("Index");
        }
    }
}