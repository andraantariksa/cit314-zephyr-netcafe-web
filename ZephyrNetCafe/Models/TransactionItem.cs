using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SqlKata.Execution;

namespace ZephyrNetCafe.Models
{
    public class TransactionItem
    {
        public long ID { get; set; }
        public long TransactionID { get; set; }
        public long ItemID { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        const string TableName = "TransactionItem";

        public void Insert()
        {
            ID = DBContext.Instance.DB.Query(TableName)
                .InsertGetId<long>(new
                {
                    TransactionID,
                    ItemID,
                    Price,
                    Quantity
                });
        }

        public static IEnumerable<TransactionItem> GetManyForTransactionID(long transactionID)
        {
            return DBContext.Instance.DB.Query(TableName)
                .Where(nameof(TransactionID), transactionID)
                .Get<TransactionItem>();
        }
    }
}
