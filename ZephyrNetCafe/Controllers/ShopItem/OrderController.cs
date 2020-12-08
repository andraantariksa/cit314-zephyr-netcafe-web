using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ZephyrNetCafe.Controllers.ShopItem
{
    public class OrderController : Controller
    {
        public class OrderField
        {
            public int Quantity;
            public long ProductID;
        }

        [HttpPost]
        public JsonResult Post(OrderField field)
        {
            var result = new Result<Models.Item>();
            try
            {

            }
            catch (Models.DBException ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return Json(result);
        }
    }
}
