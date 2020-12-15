using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ZephyrNetCafe.Controllers.User
{
    [ApiController]
    [Route("/api/user/single/")]
    public class UserGetFieldController: ControllerBase
    {
        [HttpGet("{username}")]
        public ActionResult<IEnumerable<Models.User>> Get(string username)
        {
            Models.User foundUser;
            try
            {
                foundUser = Models.User.GetByUsername(username);
            }
            catch (SqlException ex)
            {
                return BadRequest(new
                {
                    Message = ex.Message
                });
            }
            return Ok(foundUser);
        }
    }
}
