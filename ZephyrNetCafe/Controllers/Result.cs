using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZephyrNetCafe.Controllers
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public string Message;
        public T Data;

        public Result()
        {
            IsSuccess = true;
            Data = default(T);
        }
    }
}
