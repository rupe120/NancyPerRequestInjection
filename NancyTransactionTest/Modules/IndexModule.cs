using System;
using System.Threading.Tasks;
using AsyncPoco;
using Nancy;
using NancyTransactionTest.Infrastructure;

namespace NancyTransactionTest.Modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            //Database database, IInjectedServiceTest injectedServiceTest
            Get["/", true] = async (parameters, ctx) =>
            {
                //using (var trans = await database.GetTransactionAsync())
                //{
                //    await injectedServiceTest.InsertStuff(database);
                //    await database.ExecuteAsync("insert into test (name) values (@0)", "c: " + DateTime.Now.ToString());
                //}
                return View["index"];
            };
        }
    }

    public class ServiceTest
    {
        public static async Task InsertStuff(Database database)
        {
            await database.ExecuteAsync("insert into test (name) values (@0)", DateTime.Now.ToString());
        }
    }
}