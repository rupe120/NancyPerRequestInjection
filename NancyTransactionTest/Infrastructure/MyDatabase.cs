using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using AsyncPoco;

namespace NancyTransactionTest.Infrastructure
{
    public class MyDatabase : Database
    {
        public MyDatabase() : base("TransactionTest")
        {
            
        }

        public MyDatabase(DbConnection connection) : base(connection)
        {
        }

        public MyDatabase(string connectionString, string providerName) : base(connectionString, providerName)
        {
        }

        public MyDatabase(string connectionString, DbProviderFactory provider) : base(connectionString, provider)
        {
        }

        public MyDatabase(string connectionStringName) : base(connectionStringName)
        {
        }
    }
}