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
        public class Items
        {
            public long ItemID { get; set; }
            public int Quantity { get; set; }
            public int Price { get; set; }
        };

        public class TransactionAddField
        {
            public string UserUsername { get; set; }
            public List<Items> Items { get; set; }
            public string AuthUsername { get; set; }
            public string AuthPassword { get; set; }
        }

        [HttpPost]
        public ActionResult Post(TransactionAddField field)
        {
            try
            {
                var authUser = Models.User.GetByUsernameAndPassword(field.AuthUsername, field.AuthPassword);
                if (authUser == null || !authUser.IsMinimumStaff())
                {
                    return StatusCode(403);
                }

                var user = Models.User.GetByUsername(field.UserUsername);
                if (user == null)
                {
                    return BadRequest(new
                    {
                        Message = "User does not exists"
                    });
                }

                var transaction = new Models.Transaction();
                transaction.UserID = user.ID;
                transaction.CreatedAt = DateTime.Now;
                transaction.Insert();

                foreach (Items item in field.Items)
                {
                    var transactionItem = new Models.TransactionItem();
                    transactionItem.ItemID = item.ItemID;
                    transactionItem.TransactionID = transaction.ID;
                    transactionItem.Quantity = item.Quantity;
                    transactionItem.Price = item.Price;
                    transactionItem.Insert();
                }
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
