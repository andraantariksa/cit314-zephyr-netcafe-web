using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ZephyrNetCafe.Controllers.ShopItem
{
    public class ShopItemOrderController : ControllerBase
    {
        public class ShopItemOrderField
        {
            public int Quantity;
            public long ProductID;
        }

        [HttpPost]
        public ActionResult Post(ShopItemOrderField field)
        {
            return Ok();
        }
    }
}
