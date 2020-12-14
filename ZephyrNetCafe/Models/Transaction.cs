using SqlKata.Execution;
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

        const string TableName = "Transaction";

        public long Insert()
        {
            return DBContext.Instance.DB.Query(TableName)
                .InsertGetId<long>(this);
        }

        public static IEnumerable<Transaction> GetMany(int limit = -1, int offset = -1)
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
            return query.Get<Transaction>();
        }
    }
}
