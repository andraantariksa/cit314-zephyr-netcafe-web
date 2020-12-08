using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ZephyrNetCafe.Controllers.Computer
{
    public class ComputerAddUsageController: ControllerBase
    {
        public class ComputerAddUsageDurationField
        {
            public long AddedDuration;
            public long TimeStarted;
            public long UserID;
            public long ComputerID;
        }

        [HttpPost]
        public ActionResult Post(ComputerAddUsageController field)
        {
            return Ok();
        }
    }
}
