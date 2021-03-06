﻿using ComputerShop.Data.Models;
using ComputerShop.Data.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace ComputerShop.Web.Api
{
    public class RepairsController : ApiController
    {
        private readonly IShopData db;

        public RepairsController(IShopData db)
        {
            this.db = db;
        }

        public IEnumerable<Repair> Get()
        {
            var model = db.GetRepairs();
            return model;
        }
    }
}
