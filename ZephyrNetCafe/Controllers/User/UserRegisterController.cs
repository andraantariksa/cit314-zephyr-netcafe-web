using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace ZephyrNetCafe.Controllers.User
{
    public class UserRegisterController : Controller
    {
        [HttpPost]
        public JsonResult Post(Models.User user)
        {
            var result = new Result<Models.User>();
            try
            {
                user.Insert();
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
