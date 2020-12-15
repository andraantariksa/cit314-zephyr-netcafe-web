using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ZephyrNetCafe.Controllers.ShopItem
{
    [ApiController]
    [Route("/api/shop")]
    public class ShopItemAddController : ControllerBase
    {
        public class ShopItemAddField
        {
            public string Name { get; set; }
            public int Price { get; set; }
            public int Quantity { get; set; }
            public string AuthUsername { get; set; }
            public string AuthPassword { get; set; }
        }

        [HttpPost]
        public ActionResult Post(ShopItemAddField field)
        {
            try
            {
                var authUser = Models.User.GetByUsernameAndPassword(field.AuthUsername, field.AuthPassword);
                if (authUser == null || !authUser.IsMinimumAdmin())
                {
                    return StatusCode(403);
                }

                // Add transaction
                var item = new Models.Item();
                item.Name = field.Name;
                item.Price = field.Price;
                item.Quantity = field.Quantity;
                item.Insert();
            }
            catch (SqlException ex)
            {
                return BadRequest(new
                {
                    Message = ex.Message
                });
            }
            return Ok();
        }
    }
}
