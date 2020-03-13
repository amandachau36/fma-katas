using System;

namespace DatabaseCommand
{
    public class SqlConnection :  MyDbConnection
    {
        public SqlConnection(string connectionString) : base(connectionString)
        {
        }

        public override void OpenConnection()
        {
            Console.WriteLine("Opening Sql Connection");
        }

        public override void CloseConnection()
        {
            Console.WriteLine("closing sql connection");
        }
    }
}