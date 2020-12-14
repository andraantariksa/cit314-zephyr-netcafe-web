using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZephyrNetCafe.Models
{
    public class Computer
    {
        public long ID;
        public string Name;
        public string Spec;
        public byte IsDeleted;

        const string TableName = "Computer";

        public long Insert()
        {
            return DBContext.Instance.DB.Query(TableName)
                .InsertGetId<long>(this);
        }

        public static IEnumerable<Computer> GetMany()
        {
            return DBContext.Instance.DB.Query(TableName)
                .Get<Computer>();
        }

        public static IEnumerable<Computer> GetAvailability(int limit = -1, int offset = -1)
        {
            var query = DBContext.Instance.DB.Query(TableName);
            // Some algo here query.Join
            return query.Get<Computer>();
        }
        public static void Update(long key, object data)
        {
            DBContext.Instance.DB.Query(TableName)
                .Where(nameof(ID), key)
                .Update(data);
        }
    }
}
