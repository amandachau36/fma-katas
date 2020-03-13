using System;

namespace DatabaseCommand
{
    public class OracleConnection : MyDbConnection
    {
        public OracleConnection(string connectionString) : base(connectionString)
        {
        }

        public override void OpenConnection()
        {
            Console.WriteLine("Opening Oracle connection");
        }

        public override void CloseConnection()
        {
            Console.WriteLine("Closing Oracle connection");
        }
    }
}