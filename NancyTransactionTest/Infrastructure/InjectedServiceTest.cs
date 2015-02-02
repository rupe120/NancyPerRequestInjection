using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AsyncPoco;

namespace NancyTransactionTest.Infrastructure
{
    public class InjectedServiceTest : IInjectedServiceTest
    {
        private readonly MyDatabase _database;

        public InjectedServiceTest(MyDatabase database)
        {
            _database = database;
        }

        public async Task InsertStuff(MyDatabase database)
        {
            await database.ExecuteAsync("insert into test (name) values (@0)", "a: " + DateTime.Now.ToString());
            await _database.ExecuteAsync("insert into test (name) values (@0)", "b: " + DateTime.Now.ToString());
        }
    }
}