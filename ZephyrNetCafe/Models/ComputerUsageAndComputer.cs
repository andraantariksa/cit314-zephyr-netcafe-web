using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZephyrNetCafe.Models
{
    public class ComputerUsageAndComputer
    {
        public long ComputerID;
        public string ComputerName;
        public string ComputerSpec;
        public byte ComputerIsDeleted;
        public long ComputerUsageID;
        public long ComputerUsageUserID;
        public long ComputerUsageComputerID;
        public DateTime ComputerUsageEndDateTime;
        public DateTime ComputerUsageStartDateTime;
    }
}
