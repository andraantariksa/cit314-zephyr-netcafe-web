using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZephyrNetCafe.Controllers.User
{
    [ApiController]
    [Route("/api/user")]
    public class UserRegisterController : ControllerBase
    {
        public class UserField
        {
            public long ID;
            public string Name { get; set; }
            public string Email { get; set; }
            public string Username { get; set; }
            public string Password { get;  set; }
        }

        [HttpPost]
        public ActionResult<UserField> Post(UserField field)
        {
            try
            {
                field.ID = Models.User.Insert(field.Email, field.Name, field.Username, field.Password, Models.User.Roles.User);
            }
            catch (SqlException ex)
            {
                return BadRequest(new {
                    Message = ex.Message
                });
            }
            return CreatedAtAction(nameof(Post), field);
        }
    }
}
