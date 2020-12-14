using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ZephyrNetCafe.Controllers.Computer
{
    [ApiController]
    [Route("/api/computer")]
    public class ComputerAddController: ControllerBase
    {
        public class ComputerAddField
        {
            public string Name { get; set; }
            public string Spec { get; set; }
            public string AuthUsername { get; set; }
            public string AuthPassword { get; set; }
        }

        [HttpPost]
        public ActionResult Post(ComputerAddField field)
        {
            try
            {
                var authUser = Models.User.GetByUsernameAndPassword(field.AuthUsername, field.AuthPassword);
                if (authUser == null)
                {
                    return StatusCode(403);
                }
                if (!authUser.IsMinimumAdmin())
                {
                    return StatusCode(403);
                }

                var computer = new Models.Computer();
                computer.Name = field.Name;
                computer.Spec = field.Spec;
                computer.Insert();
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
