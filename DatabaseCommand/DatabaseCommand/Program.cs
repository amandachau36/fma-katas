using System;

namespace DatabaseCommand
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var sqlConnection = new SqlConnection("sqlsqlsql");
            
                var oracleConnection = new OracleConnection("ORACLEEE");
            
                var dbCommand = new MyDbCommand(oracleConnection,  "hello world");

                dbCommand.Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
           
            }
      ;


        }
    }
}