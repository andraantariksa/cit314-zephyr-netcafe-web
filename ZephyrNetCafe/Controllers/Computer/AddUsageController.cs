using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ZephyrNetCafe.Controllers.Computer
{
    public class AddUsageController: Controller
    {
        public class AddUsageDurationField
        {
            public long AddedDuration;
            public long TimeStarted;
            public long UserID;
            public long ComputerID;
        }

        [HttpPost]
        public JsonResult Post(Models.ComputerUsage field)
        {
            var result = new Result<Models.ComputerUsage>();
            try
            {
                //field.Insert();
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
