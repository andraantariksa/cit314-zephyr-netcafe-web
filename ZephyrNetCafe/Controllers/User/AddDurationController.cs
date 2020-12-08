using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ZephyrNetCafe.Controllers.User
{
    public class AddDurationController : Controller
    {
        public class AddDurationField
        {
            public long AddedDuration;
            public long UserID;
        }

        [HttpPost]
        public JsonResult Post(AddDurationField field)
        {
            var result = new Result<Models.User>();
            try
            {
                var user = Models.User.GetByKey(field.UserID);
                Models.User.Update(field.UserID, new { 
                    Duration = user.Duration + field.AddedDuration
                });
            }
            catch (Models.DBException ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }

            return Json(result);
        }
    }
}
