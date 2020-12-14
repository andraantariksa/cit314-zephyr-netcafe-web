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
    public class ShopItemDeleteController : ControllerBase
    {
        public class ShopItemDeleteField
        {
            public long ProductID { get; set; }
            public string AuthUsername { get; set; }
            public string AuthPassword { get; set; }
        }

        [HttpDelete]
        public ActionResult Delete(ShopItemDeleteField field)
        {
            try
            {
                var authUser = Models.User.GetByUsernameAndPassword(field.AuthUsername, field.AuthPassword);
                if (authUser == null)
                {
                    return StatusCode(403);
                }
                if (!authUser.IsMinimumStaff())
                {
                    return StatusCode(403);
                }

                // Add transaction
                var item = Models.Item.GetByKey(field.ProductID);
                if (item == null)
                {
                    return BadRequest(new
                    {
                        Message = "Item does not exists"
                    });
                }

                Models.Item.Update(field.ProductID, new { 
                    Deleted = 1
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
