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
    public class TransactionListUserController : ControllerBase
    {
        [HttpGet("{username}")]
        public ActionResult<List<Tuple<Models.Transaction, List<Models.TransactionItem>>>> Get(string username)
        {
            var transactions = new List<Tuple<Models.Transaction, List<Models.TransactionItem>>>();
            try
            {
                var user = Models.User.GetByUsername(username);
                if (user == null)
                {
                    return BadRequest(new
                    {
                        Message = "There is no existing user"
                    });
                }
                IEnumerable<Models.Transaction> foundTransactions = Models.Transaction.GetManyForUserID(user.ID);
                foreach (Models.Transaction transaction in foundTransactions)
                {
                    IEnumerable<Models.TransactionItem>  foundTransactionItems = Models.TransactionItem.GetManyForTransactionID(transaction.ID);
                    transactions.Add(new Tuple<Models.Transaction, List<Models.TransactionItem>>(transaction, foundTransactionItems.ToList()));
                }
            }
            catch (SqlException ex)
            {
                return BadRequest(new
                {
                    Message = ex.Message
                });
            }
            return Ok(transactions);
        }
    }
}
