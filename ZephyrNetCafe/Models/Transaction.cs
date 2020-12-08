using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZephyrNetCafe.Models
{
    public class Transaction
    {
        public long ID;
        public long UserID;
        public long ItemID;
        public DateTime CreatedAt;
        public int Price;
        public int Quantity;
    }
}
