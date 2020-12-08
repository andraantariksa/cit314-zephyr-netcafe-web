using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZephyrNetCafe.Models
{
    public class DBException : Exception
    {
        public DBException()
        {
        }

        public DBException(string message):
            base($"Database error: {message}")
        {
        }
    }
}
