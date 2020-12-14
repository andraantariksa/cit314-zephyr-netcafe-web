using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ZephyrNetCafe.Controllers.User
{
    [ApiController]
    [Route("/api/user")]
    public class UserEditController : ControllerBase
    {
        public class UserEditField
        {
            public long UserID { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public Models.User.Roles Role { get; set; }
            public string AuthUsername { get; set; }
            public string AuthPassword { get; set; }
        }

        [HttpPut]
        public ActionResult Put(UserEditField field)
        {
            try
            {
                var authUser = Models.User.GetByUsernameAndPassword(field.AuthUsername, field.AuthPassword);
                if (authUser == null)
                {
                    return StatusCode(403);
                }
                if (!(authUser.IsMinimumStaff() || authUser.ID == field.UserID))
                {
                    return StatusCode(403);
                }

                var user = Models.User.GetByKey(field.UserID);
                if (user == null)
                {
                    return BadRequest(new
                    {
                        Message = "User does not exists"
                    });
                }
                Models.User.Update(field.UserID, new
                {
                    Name = field.Name,
                    Email = field.Email,
                    Password = field.Password,
                    Role = field.Role
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
