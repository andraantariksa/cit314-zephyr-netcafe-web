using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ZephyrNetCafe.Controllers.User
{
    [ApiController]
    [Route("/api/user/auth")]
    public class UserLoginController : ControllerBase
    {
        public class UserLoginField
        {
            public string Username { set; get; }
            public string Password { set; get; }
        }

        [HttpPost]
        public ActionResult Post(UserLoginField field)
        {
            try
            {
                var foundUser = Models.User.GetByUsernameAndPassword(field.Username, field.Password);
                if (foundUser == null)
                {
                    return StatusCode(403);
                }
            }
            catch (SqlException ex)
            {
                return BadRequest(new {
                    Message = ex.Message
                });
            }
            return Ok();
        }
    }
}
