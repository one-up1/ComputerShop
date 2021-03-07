using ComputerShop.Data.Models;
using ComputerShop.Data.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
            var model = new IndexViewModel();
            var repairs = db.GetRepairs();
            model.RepairCount = repairs.Count();
            if (model.RepairCount != 0)
            {
                model.RepairPartsCount = db.GetRepairPartsCount();
                if (model.RepairPartsCount != 0)
                {
                    model.RepairPartsTotalPrice = db.GetRepairPartsPriceSum();
                }

                model.RepairStatusCounts = new Dictionary<Status, int>();
                model.RepairStatusCounts.Add(Status.Pending, 0);
                model.RepairStatusCounts.Add(Status.InProgress, 0);
                model.RepairStatusCounts.Add(Status.WaitingForParts, 0);
                model.RepairStatusCounts.Add(Status.Completed, 0);
                foreach (var repair in repairs)
                {
                    model.RepairStatusCounts[repair.Status]++;
                }
            }
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

    public class IndexViewModel
    {
        public int RepairCount { get; set; }

        public int RepairPartsCount { get; set; }

        [DataType(DataType.Currency)]
        public double RepairPartsTotalPrice { get; set; }

        public Dictionary<Status, int> RepairStatusCounts { get; set; }
    }
}