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
    public class TransactionListController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Models.Transaction>> Get()
        {
            IEnumerable<Models.Transaction> foundTransactions;
            try
            {
                foundTransactions = Models.Transaction.GetMany();
            }
            catch (SqlException ex)
            {
                return BadRequest(new
                {
                    Message = ex.Message
                });
            }
            return Ok(foundTransactions);
        }
    }
}
