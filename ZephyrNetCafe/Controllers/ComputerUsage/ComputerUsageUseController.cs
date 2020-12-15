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
    public class ComputerUsageUseController : ControllerBase
    {
        public class ComputerUsageUseField
        {
            public long ComputerUsageID { get; set; }
        }

        [HttpPut]
        public ActionResult Put(ComputerUsageUseField field)
        {
            try
            {
                var computerUsage = Models.ComputerUsage.GetByKey(field.ComputerUsageID);
                if (computerUsage == null)
                {
                    Console.WriteLine("Computer usage does not exists");
                    return BadRequest(new
                    {
                        Message = "Computer usage does not exists"
                    });
                }

                Models.ComputerUsage.Update(field.ComputerUsageID, new
                {
                    EndDateTime = DateTime.Now
                });
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new
                {
                    Message = ex.Message
                });
            }
            return Ok();
        }
    }
}
