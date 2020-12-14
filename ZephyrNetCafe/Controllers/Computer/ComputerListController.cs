using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ZephyrNetCafe.Controllers.Computer
{
    [ApiController]
    [Route("/api/computer")]
    public class ComputerListController : ControllerBase
    {
        public class ComputerListField
        {
            public string AuthUsername { get; set; }
            public string AuthPassword { get; set; }
        }

        [HttpGet]
        public ActionResult Get(ComputerListField field)
        {
            IEnumerable<Models.Computer> foundComputers;
            try
            {
                foundComputers = Models.Computer.GetMany();
            }
            catch (SqlException ex)
            {
                return BadRequest(new
                {
                    Message = ex.Message
                });
            }
            return Ok(foundComputers.Where((computer) => computer.IsDeleted == 1));
        }
    }
}
