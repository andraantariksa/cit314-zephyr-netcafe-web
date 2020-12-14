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
    public class ComputerDeleteController: ControllerBase
    {
        public class ComputerDeleteField
        {
            public long ComputerID { get; set; }
            public string AuthUsername { get; set; }
            public string AuthPassword { get; set; }
        }

        [HttpDelete]
        public ActionResult Delete(ComputerDeleteField field)
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

                Models.Computer.Update(field.ComputerID, new
                {
                    IsDeleted = 1
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
