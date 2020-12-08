using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZephyrNetCafe.Controllers
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        private T Data;
    }
}
