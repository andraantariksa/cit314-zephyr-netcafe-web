using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SqlKata.Execution;

namespace ZephyrNetCafe.Models
{
    public class Item
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public byte IsDeleted { get; set; }

        const string TableName = "Item";

        public void Insert()
        {
            ID = DBContext.Instance.DB.Query(TableName)
                .InsertGetId<long>(this);
        }

        public static void Update(long key, object data)
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

        public static Item GetByKey(long key)
        {
            return DBContext.Instance.DB.Query(TableName)
                .Where(nameof(ID), key)
                .Get<Item>()
                .SingleOrDefault();
        }

        public static IEnumerable<Item> GetMany(int limit = -1, int offset = -1)
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
            return query.Get<Item>();
        }
    }
}
