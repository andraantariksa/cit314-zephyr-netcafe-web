using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZephyrNetCafe.Models
{
    public class ComputerUsageAndComputer
    {
        public long ComputerID { get; set; }
        public string ComputerName { get; set; }
        public string ComputerSpec { get; set; }
        public byte ComputerIsDeleted { get; set; }
        public long ComputerUsageID { get; set; }
        public long ComputerUsageUserID { get; set; }
        public long ComputerUsageComputerID { get; set; }
        public DateTime ComputerUsageEndDateTime { get; set; }
        public DateTime ComputerUsageStartDateTime { get; set; }
    }
}
