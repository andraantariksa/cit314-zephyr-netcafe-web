using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ZephyrNetCafe.Controllers.User
{
    [ApiController]
    [Route("/api/user/durationreduce")]
    public class UserReduceDurationController : ControllerBase
    {
        public class ReduceDurationField
        {
            public int ReducedDuration { get; set; }
            public string AuthUsername { get; set; }
            public string AuthPassword { get; set; }
        }

        [HttpPost]
        public ActionResult Post(ReduceDurationField field)
        {
            try
            {
                var authUser = Models.User.GetByUsernameAndPassword(field.AuthUsername, field.AuthPassword);
                if (authUser == null)
                {
                    return StatusCode(403);
                }

                var user = Models.User.GetByUsername(field.AuthUsername);
                if (user == null)
                {
                    return BadRequest(new
                    {
                        Message = "User does not exists"
                    });
                }
                Models.User.Update(user.ID, new {
                    Duration = user.Duration - field.ReducedDuration
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
