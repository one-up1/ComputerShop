using ComputerShop.Data.Models;
using ComputerShop.Data.Services;
using System;
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
                db.Add(repair);
                return RedirectToAction("Details", new { id = repair.Id });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
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
                db.Update(repair);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}