using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ZephyrNetCafe.Controllers.User
{
    public class LoginController : Controller
    {
        public class UserLoginField
        {
            public string Username;
            public string Password;
        }

        [HttpPost]
        public JsonResult Post(UserLoginField field)
        {
            var result = new Result<Models.User>();
            try
            {
                var foundUser = Models.User.GetByUsernameAndPassword(field.Username, field.Password);
                if (foundUser != null)
                {
                    result.Data = foundUser;
                }
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
