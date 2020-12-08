using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZephyrNetCafe.Models
{
    public class ComputerUsage
    {
        public long ID;
        public long UserID;
        public long ComputerID;
        public long Duration;
        public DateTime StartFrom;
    }
}
