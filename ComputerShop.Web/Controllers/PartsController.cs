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

        public ActionResult Details(int id)
        {
            var model = db.GetPart(id);
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
        public ActionResult Create(Part part)
        {
            if (ModelState.IsValid)
            {
                db.AddPart(part);
                return RedirectToAction("Details", new { id = part.Id });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.GetPart(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Part part)
        {
            if (ModelState.IsValid)
            {
                db.UpdatePart(part);
                TempData["Message"] = "Onderdeel opgeslagen";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.GetPart(id);
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
            db.DeletePart(id);
            return RedirectToAction("Index");
        }
    }
}