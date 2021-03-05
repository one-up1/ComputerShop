using ComputerShop.Data.Models;
using ComputerShop.Data.Services;
using System.Web.Mvc;
using System.Collections.Generic;

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
            var model = new RepairPartsViewModel();
            model.RepairId = id;
            model.RepairParts = db.GetRepairParts(id);

            model.Parts = new List<SelectListItem>();
            foreach (var part in db.GetParts())
            {
                var item = new SelectListItem()
                {
                    Text = part.Name,
                    Value = part.Id.ToString()
                };
                model.Parts.Add(item);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int repairId, int value)
        {
            if (ModelState.IsValid)
            {
                db.AddRepairPart(repairId, value);
                return RedirectToAction("Index", new { id = repairId });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            int repairId = db.DeleteRepairPart(id);
            return RedirectToAction("Index", new { id = repairId });
        }
    }

    public class RepairPartsViewModel
    {
        public int RepairId { get; set; }

        public IEnumerable<RepairPart> RepairParts { get; set; }

        public IList<SelectListItem> Parts { get; set; }
    }
}