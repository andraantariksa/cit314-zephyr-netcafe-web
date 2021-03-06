﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ZephyrNetCafe.Controllers.ShopItem
{
    [ApiController]
    [Route("/api/shop/order")]
    public class ShopItemOrderController : ControllerBase
    {
        public class ShopItemOrderField
        {
            public long ProductID { get; set; }
            public string AuthUsername { get; set; }
            public string AuthPassword { get; set; }
        }

        [HttpPost]
        public ActionResult Post(ShopItemOrderField field)
        {
            // TODO
            // Add transaction
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

                var item = Models.Item.GetByKey(field.ProductID);
                if (item == null)
                {
                    return BadRequest(new
                    {
                        Message = "Item does not exists"
                    });
                }

                if (item.Quantity <= 0)
                {
                    return BadRequest(new
                    {
                        Message = "No quantity left"
                    });
                }

                Models.Item.Update(field.ProductID, new
                {
                    Quantity = item.Quantity - 1
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
