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
        public DateTime CreatedAt;

        const string TableName = "Transaction";

        public void Insert()
        {
            ID = DBContext.Instance.DB.Query(TableName)
                .InsertGetId<long>(new
                {
                    UserID,
                    CreatedAt
                });
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

        public static IEnumerable<Transaction> GetManyForUserID(long userID)
        {
            return DBContext.Instance.DB.Query(TableName)
                .Where(nameof(UserID), userID)
                .Get<Transaction>();
        }
    }
}
