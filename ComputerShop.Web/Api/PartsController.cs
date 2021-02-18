using ComputerShop.Data.Models;
using ComputerShop.Data.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace ComputerShop.Web.Api
{
    public class PartsController : ApiController
    {
        private readonly IShopData db;

        public PartsController(IShopData db)
        {
            this.db = db;
        }

        public IEnumerable<Part> Get()
        {
            var model = db.GetParts();
            return model;
        }
    }
}
