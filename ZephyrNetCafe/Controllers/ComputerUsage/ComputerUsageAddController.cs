using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ZephyrNetCafe.Controllers.ComputerUsage
{
    [ApiController]
    [Route("/api/computerusage")]
    public class ComputerUsageAddController : ControllerBase
    {
        public class ComputerUsageAddField
        {
            public long UserID { get; set; }
            public long ComputerID { get; set; }
        }

        [HttpPost]
        public ActionResult Post(ComputerUsageAddField field)
        {
            long computerUsageID;
            try
            {
                var computerUsage = new Models.ComputerUsage();
                computerUsage.UserID = field.UserID;
                computerUsage.StartDateTime = DateTime.Now;
                computerUsage.EndDateTime = DateTime.Now;
                computerUsage.ComputerID = field.ComputerID;
                computerUsageID = computerUsage.Insert();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new
                {
                    Message = ex.Message
                });
            }
            return Ok(new
            {
                ComputerUsageID = computerUsageID
            });
        }
    }
}
