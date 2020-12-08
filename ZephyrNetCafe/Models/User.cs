using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZephyrNetCafe.Models
{
    public class User
    {
        public enum Roles
        {
            Admin = 0,
            Staff = 1,
            User = 2
        };

        public long ID { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long Duration { get; set; }
        public Roles Role { get; set; }
    }
}
