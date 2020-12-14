using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ZephyrNetCafe.Controllers.ComputerUsage
{
    [ApiController]
    [Route("/api/computerusage/now")]
    public class ComputerUsageListNowController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            IEnumerable<Models.ComputerUsageAndComputer> foundComputerUsageNow;
            try
            {
                foundComputerUsageNow = Models.ComputerUsage.GetUsageNowMany();
            }
            catch (SqlException ex)
            {
                return BadRequest(new
                {
                    Message = ex.Message
                });
            }
            return Ok(foundComputerUsageNow));
        }
    }
}
