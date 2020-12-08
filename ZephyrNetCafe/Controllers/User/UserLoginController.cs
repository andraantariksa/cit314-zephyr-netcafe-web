using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ZephyrNetCafe.Controllers.User
{
    public class UserLoginController : ControllerBase
    {
        [ApiController]
        [Route("/api/user/auth")]
        public class UserLoginField
        {
            public string Username;
            public string Password;
        }

        [HttpPost]
        public ActionResult Post(UserLoginField field)
        {
            try
            {
                var foundUser = Models.User.GetByUsernameAndPassword(field.Username, field.Password);
                if (foundUser != null)
                {
                    return Forbid();
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
