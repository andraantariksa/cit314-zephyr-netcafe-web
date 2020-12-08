﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ZephyrNetCafe.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options):
            base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<ShopItem> ShopItem { get; set; }
    }
}
