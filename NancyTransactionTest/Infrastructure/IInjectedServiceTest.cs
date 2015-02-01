using System.Threading.Tasks;
using AsyncPoco;

namespace NancyTransactionTest.Infrastructure
{
    public interface IInjectedServiceTest
    {
        Task InsertStuff(Database database);
    }
}