using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SqlKata.Execution;

namespace ZephyrNetCafe.Models
{
    public class Item
    {
        public long ID;
        public string Name;
        public long Price;

        const string TableName = "item";

        public void Insert()
        {
            DBContext.Instance.DB.Query(TableName)
                .Insert(this);
        }

        public static void Delete(long key)
        {
            DBContext.Instance.DB.Query(TableName)
                .Where(nameof(ID), key)
                .Delete();
        }

        public void Update(long key, object data)
        {
            DBContext.Instance.DB.Query(TableName)
                .Where(nameof(ID), key)
                .Update(data);
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
    }
}
