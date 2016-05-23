using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Holt.DataAccess;
using Holt.DataAccess.DataModel;

namespace DataAccessTester
{
    /// <summary>
    /// Trivial test program to illustrate how to create a data source and data store
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var dummySource = new DbFacadeDataSource();
            var dataStore = new CrsDataStore(dummySource);

            var customers = dataStore.GetCustomers();
            customers.ForEach(c => { PrintCustomerInformation(c); });

            Console.WriteLine("Done...");
            Console.ReadKey();
        }


        private static void PrintCustomerInformation(Customer c)
        {
            Console.WriteLine(c.Name);
            Console.WriteLine(c.Address);
            Console.WriteLine();
        }
    }
}
