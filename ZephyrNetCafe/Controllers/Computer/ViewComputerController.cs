using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ZephyrNetCafe.Controllers.Computer
{
    public class ViewComputerController : Controller
    {

        [HttpGet]
        public JsonResult Get()
        {

            return Json(true);
        }
    }
}
