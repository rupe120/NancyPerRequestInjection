using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;
using AsyncPoco;
using Nancy.Hosting.Aspnet;
using Nancy.TinyIoc;
using NancyTransactionTest.Infrastructure;

namespace NancyTransactionTest
{
    public class TinyIocConfig
    {
        public static void Config(TinyIoCContainer container)
        {
            //container.Register<Database>().UsingConstructor(() => new Database("TransactionTest"));//.AsPerRequestSingleton();
            container.Register<MyDatabase>().AsPerRequestSingleton();

            // Register all types in QIRTServices.Web.Infrastructure with at least one interface. 
            //
            // The first interface will be used for reference.
            //
            var webAssembly = Assembly.GetExecutingAssembly();

            var webRegistrations =
                (from type in webAssembly.GetExportedTypes()
                 where type.Namespace != null
                 where type.Namespace.StartsWith("NancyTransactionTest.Infrastructure")
                 where type.IsAbstract == false
                 where type.GetInterfaces().Any()
                 select new
                 {
                     Interface = type.GetInterfaces().First(),
                     Implementation = type
                 }).ToList();

            Debug.WriteLine("NancyTransactionTest.Infrastructure instances found: {0}", webRegistrations.Count());

            foreach (var reg in webRegistrations)
            {
                container.Register(reg.Interface, reg.Implementation);
            }
        }
    }
}