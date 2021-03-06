﻿using ComputerShop.Data.Models;
using ComputerShop.Data.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
            var model = new RepairPartsViewModel();
            model.RepairId = id;
            model.RepairParts = db.GetRepairParts(id);
            if (model.RepairParts.Count() > 1)
            {
                model.PartsTotalPrice = db.GetRepairPartsPriceSum(id);
            }

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
            }
            return RedirectToAction("Index", new { id = repairId });
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

        [DataType(DataType.Currency)]
        public double PartsTotalPrice { get; set; }

        public IList<SelectListItem> Parts { get; set; }
    }
}