using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ZephyrNetCafe.Controllers
{
    public class UserAddDuration : Controller
    {
        private Models.DBContext DBContext;

        public class AddDurationField
        {
            public long Duration;
            public long UserID;
        }

        [HttpPost]
        public JsonResult Post(AddDurationField data)
        {
            var foundUser = DBContext.User
                .SingleOrDefault(user => user.ID == data.UserID);
            var result = new Result<AddDurationField>();
            try
            {
                if (DBContext.SaveChanges() > 0)
                {
                    result.IsSuccess = false;
                }
                else
                {
                    result.IsSuccess = true;
                }
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                result.IsSuccess = false;
            }

            return Json(result);
        }
    }
}
