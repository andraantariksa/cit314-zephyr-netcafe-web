using SqlKata.Execution;
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
            Customer = 2
        };

        public long ID { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Duration { get; set; }
        public Roles Role { get; set; }


        public const string TableName = "user";

        public static User GetByUsernameAndPassword(string username, string password)
        {
            return DBContext.Instance.DB.Query(TableName)
                .Where(nameof(Username), username)
                .Where(nameof(Password), password)
                .Get<User>()
                .FirstOrDefault();
        }

        public static long Insert(string email, string name, string username, string password, Roles role)
        {
            return DBContext.Instance.DB.Query(TableName)
                .InsertGetId<long>(new {
                    Username = username,
                    Name = name,
                    Email = email,
                    Password = password,
                    Role = (byte)role
                });
        }

        /*
        public static void Delete(long key)
        {
            DBContext.Instance.DB.Query(TableName)
                .Where(nameof(ID), key)
                .Delete();
        }*/

        public static void Update(long key, object data)
        {
            DBContext.Instance.DB.Query(TableName)
                .Where(nameof(ID), key)
                .Update(data);
        }

        public static IEnumerable<User> GetMany(int limit = -1, int offset = -1)
        {
            var query = DBContext.Instance.DB.Query(TableName);
            if (limit >= 0)
            {
                query = query.Limit(limit);
            }
            if (offset >= 0)
            {
                query = query.Offset(offset);
            }
            return query.Get<User>();
        }

        public static User GetByKey(long key)
        {
            return DBContext.Instance.DB.Query(TableName)
                .Where(nameof(ID), key)
                .Get<User>()
                .SingleOrDefault();
        }

        public static User GetByUsername(string username)
        {
            return DBContext.Instance.DB.Query(TableName)
                .Where(nameof(Username), username)
                .Get<User>()
                .SingleOrDefault();
        }

        public bool IsMinimumAdmin()
        {
            return Role <= Roles.Admin;
        }

        public bool IsMinimumStaff()
        {
            return Role <= Roles.Staff;
        }
    }
}
