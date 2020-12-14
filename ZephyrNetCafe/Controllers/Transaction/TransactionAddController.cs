using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ZephyrNetCafe.Controllers.Computer
{
    [ApiController]
    [Route("/api/transaction")]
    public class TransactionAddController : ControllerBase
    {
        public class TransactionAddField 
        {
            public long ItemID;
            public DateTime CreatedAt;
            public int Price;
            public int Quantity;
            public string AuthUsername { get; set; }
        }

        [HttpPost]
        public ActionResult Post(TransactionAddField field)
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

                var item = Models.Item.GetByKey(field.ItemID);
                if (item == null)
                {
                    return BadRequest(new
                    {
                        Message = "Item does not exists"
                    });
                }

                var transaction = new Models.Transaction();
                transaction.Price = item.Price;
                transaction.Quantity = field.Quantity;
                transaction.ItemID = field.ItemID;
                transaction.UserID = authUser.ID;
                transaction.CreatedAt = DateTime.Now;
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
