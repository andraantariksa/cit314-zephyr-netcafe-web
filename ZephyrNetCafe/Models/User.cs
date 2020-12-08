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
            User = 2
        };

        public long ID { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public long Duration { get; set; }
        public Roles Role { get; set; }


        public const string TableName = "user";
        public static User GetByUsernameAndPassword(string username, string password)
        {
            return DBContext.Instance.DB.Query(TableName)
                .Where(nameof(Username), username)
                .Where(nameof(Password), password)
                .Get<User>()
                .SingleOrDefault();
        }

        public void Insert()
        {
            if (DBContext.Instance.DB.Query(TableName)
                .Insert(this) == 0)
            {
                throw new DBException($"Insertion {TableName} failed");
            }
        }

        public static void Delete(long key)
        {
            if (DBContext.Instance.DB.Query(TableName)
                .Where(nameof(ID), key)
                .Delete() == 0)
            {
                throw new DBException($"Deletion {TableName} failed");
            }
        }

        public static void Update(long key, object data)
        {
            if (DBContext.Instance.DB.Query(TableName)
                .Where(nameof(ID), key)
                .Update(data) == 0)
            {
                throw new DBException($"Update {TableName} failed");
            }
        }

        public static IEnumerable<User> GetLists(int limit = -1, int offset = -1)
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

        public static bool IsUserExists(long key)
        {
            return GetByKey(key) != null;
        }
    }
}
