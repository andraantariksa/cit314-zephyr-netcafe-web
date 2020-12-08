using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ZephyrNetCafe.Controllers.User
{
    [ApiController]
    [Route("/api/user/durationadd")]
    public class UserAddDurationController : ControllerBase
    {
        public class AddDurationField
        {
            public int AddedDuration { get; set; }
            public long UserID { get; set; }
        }

        [HttpPost]
        public ActionResult Post(AddDurationField field)
        {
            try
            {
                var user = Models.User.GetByKey(field.UserID);
                if (user == null)
                {
                    return BadRequest(new
                    {
                        Message = "User does not exists"
                    });
                }
                Models.User.Update(field.UserID, new {
                    Duration = user.Duration + field.AddedDuration
                });
            }
            catch (SqlException ex)
            {
                return BadRequest(new
                {
                    Message = ex.Message
                });
            }
            var userAfterUpdated = Models.User.GetByKey(field.UserID);
            return AcceptedAtAction(nameof(Post), new {
                TotalDurationNow = userAfterUpdated.Duration
            });
        }
    }
}
