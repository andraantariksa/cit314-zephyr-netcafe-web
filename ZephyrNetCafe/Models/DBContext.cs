using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using SqlKata.Execution;
using System.Data.SqlClient;
using SqlKata.Compilers;

namespace ZephyrNetCafe.Models
{
    public sealed class DBContext
    {
        private static readonly Lazy<DBContext> lazy =
            new Lazy<DBContext>(() => new DBContext());

        public static DBContext Instance { get { return lazy.Value; } }

        public QueryFactory DB;

        private DBContext()
        {
            // TODO. Configure this
            var connection = new SqlConnection("Database=zephyr;Integrated Security=SSPI;");
            var compiler = new SqlServerCompiler();
            DB = new QueryFactory(connection, compiler);
        }
    }
}
