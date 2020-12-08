using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace ZephyrNetCafe.Controllers
{
    public class UserRegisterController : Controller
    {
        private Models.DBContext DBContext;

        [HttpPost]
        public JsonResult Post(Models.User user)
        {
            DBContext.User.Add(user);
            var result = new Result<Models.User>();
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
