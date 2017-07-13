using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace without_dispose
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter x to exit, c to continue");

            while (true)
            {
                var ch = Console.ReadLine();
                if (ch == "x") break;
                else if(ch=="c") ReadOrderData(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        private static void ReadOrderData(string connectionString)
        {
            string queryString ="SELECT GETDATE() AS CurrentDateTime";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(queryString, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}", reader[0]));
                }
            }
            catch (Exception ex)
            {
                // Always call Close when done reading.
               // reader.Close();
            }

        }
    }
}
