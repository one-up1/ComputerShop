using ComputerShop.Data.Models;
using ComputerShop.Data.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace ComputerShop.Web.Api
{
    public class RepairsController : ApiController
    {
        private readonly IRepairData db;

        public RepairsController(IRepairData db)
        {
            this.db = db;
        }

        public IEnumerable<Repair> Get()
        {
            var model = db.GetAll();
            return model;
        }
    }
}
