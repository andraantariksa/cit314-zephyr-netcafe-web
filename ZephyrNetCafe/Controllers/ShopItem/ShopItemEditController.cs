using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ZephyrNetCafe.Controllers.ShopItem
{
    [ApiController]
    [Route("/api/shop/order")]
    public class ShopItemEditController : ControllerBase
    {
        public class ShopItemEditField
        {
            public long ProductID { get; set; }
            public string Name { get; set; }
            public string AuthUsername { get; set; }
            public long Price { get; set; }
            public string AuthPassword { get; set; }
        }

        [HttpPost]
        public ActionResult Post(ShopItemEditField field)
        {
            try
            {
                var authUser = Models.User.GetByUsernameAndPassword(field.AuthUsername, field.AuthPassword);
                if (authUser == null)
                {
                    return StatusCode(403);
                }
                if (!authUser.IsMinimumAdmin())
                {
                    return StatusCode(403);
                }
                Models.Item.Update(field.ProductID, new
                {
                    Name = field.Name,
                    Price = field.Price
                });
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
