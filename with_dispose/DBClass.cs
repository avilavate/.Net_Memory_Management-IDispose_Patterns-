﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace with_dispose
{
    class DBClass : IDisposable
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
                }
            }

        }
        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool v)
        {
            if (v)
            {
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

                }
            }
        }
    }


}