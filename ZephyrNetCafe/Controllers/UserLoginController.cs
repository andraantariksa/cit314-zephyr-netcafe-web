using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace ZephyrNetCafe.Controllers
{
    public class UserLoginController : Controller
    {
        private Models.DBContext DBContext;

        [HttpPost]
        public JsonResult Post(Models.User postedUser)
        {
            var foundUser = DBContext.User
                .SingleOrDefault(user =>
                    user.Username == postedUser.Username &&
                    user.Password == postedUser.Password);
            var result = new Result<Models.User>();
            try
            {
                if (foundUser == null)
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
