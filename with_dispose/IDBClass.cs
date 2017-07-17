using System;
using System.Data.SqlClient;

namespace with_dispose
{
    interface IDBClass:IDisposable
    {
        SqlCommand command { get; set; }
        SqlConnection connection { get; set; }
        SqlDataReader reader { get; set; }
        void ReadOrderData(string connectionString);
    }
}