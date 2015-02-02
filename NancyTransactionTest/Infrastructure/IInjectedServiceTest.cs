using System.Threading.Tasks;
using AsyncPoco;

namespace NancyTransactionTest.Infrastructure
{
    public interface IInjectedServiceTest
    {
        Task InsertStuff(MyDatabase database);
    }
}