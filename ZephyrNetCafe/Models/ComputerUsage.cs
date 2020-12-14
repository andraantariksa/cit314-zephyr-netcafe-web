using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZephyrNetCafe.Models
{
    public class ComputerUsage
    {
        public long ID;
        public long UserID;
        public long ComputerID;
        public DateTime EndDateTime;
        public DateTime StartDateTime;

        const string TableName = "ComputerUsage";

        public long Insert()
        {
            return DBContext.Instance.DB.Query(TableName)
                .InsertGetId<long>(this);
        }

        public static ComputerUsage GetByKey(long key)
        {
            return DBContext.Instance.DB.Query(TableName)
                .Where(nameof(ID), key)
                .Get<ComputerUsage>()
                .SingleOrDefault();
        }

        public static void Update(long key, object data)
        {
            DBContext.Instance.DB.Query(TableName)
                .Where(nameof(ID), key)
                .Update(data);
        }

        public static IEnumerable<ComputerUsageAndComputer> GetUsageNowMany()
        {
            /*string rawQuery =
                @"SELECT * FROM Computer LEFT JOIN
                ComputerUsage ON ComputerUsage.ComputerID = Computer.ID
                WHERE GETDATE() <= DATEADD(MINUTE, 3, ComputerUsage.EndDateTime)";*/
            return DBContext.Instance.DB.Query("Computer")
                .SelectRaw(@"Computer.ID as ComputerID, Computer.Name as ComputerName, Computer.Spec as ComputerSpec,
                            Computer.IsDeleted as ComputerIsDeleted, ComputerUsage.ID as ComputerUsageID,
                            ComputerUsageUserID as ComputerUsage.UserID, ComputerUsage.ComputerID as ComputerUsageComputerID,
                            ComputerUsage.EndDateTime as ComputerUsageEndDateTime, ComputerUsage.StartDateTime as ComputerUsageStartDateTime")
                .LeftJoin(
                    new SqlKata.Query("ComputerUsage"),
                    (joinedTable) => joinedTable.On("ComputerUsage.ComputerID", "Computer.ID")
                )
                .WhereRaw("GETDATE() <= DATEADD(MINUTE, 3, ComputerUsage.EndDateTime)")
                .Get<ComputerUsageAndComputer>();
        }
    }
}
