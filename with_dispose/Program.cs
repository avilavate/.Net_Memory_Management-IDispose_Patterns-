using System;
using System.Collections.Generic;

namespace with_dispose
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter x to exit, c to continue");

            //Testing if foreach calls dispose

            foreach (var loopI in new List<DBClass>() { new DBClass(), new DBClass() })
            {
                loopI.ReadOrderData(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }

            //while (true)
            //{
            //    var ch = Console.ReadLine();
            //    if (ch == "x") break;
            //    else if (ch == "c")
            //    {
            //        //DBClass obj = new DBClass();
            //        //obj.ReadOrderData(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //        using (DerivedDBClass obj1 = new DerivedDBClass())
            //        {
            //            obj1.AllocPointer();
            //            obj1.ReadOrderData(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //        }
            //    }
            //}

        }
    }
}
