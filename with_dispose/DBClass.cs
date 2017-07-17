using System;
using System.Data.SqlClient;

namespace with_dispose
{
    class DBClass :  IDBClass
    {
        public SqlCommand command { get; set; }
        public SqlConnection connection { get; set; }
        public SqlDataReader reader { get; set; }


        public void ReadOrderData(string connectionString)
        {
            string queryString = "SELECT GETDATE() AS CurrentDateTime";
            using (connection = new SqlConnection(connectionString))
            {
                using (command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    reader = command.ExecuteReader();
                }
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
                    reader.Close();
                    Console.WriteLine(ex.Message);
                }
            }

        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool v)
        {
            if (v)
            {
                Console.WriteLine("Dispose on DBClass is called!");
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
                if (command != null)
                {
                    command.Dispose();
                }
                if (reader != null)
                {
                    reader.Close();
                }
            }

        }
    }


}
