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
    public class UserListController: ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Models.User>> Get()
        {
            IEnumerable<Models.User> foundUsers;
            try
            {
                foundUsers = Models.User.GetMany();
            }
            catch (SqlException ex)
            {
                return BadRequest(new
                {
                    Message = ex.Message
                });
            }
            return Ok(foundUsers);
        }
    }
}
