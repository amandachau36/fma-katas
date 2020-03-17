using System;

namespace DatabaseCommand
{
    public class MyDbCommand
    {
        private readonly MyDbConnection _dbConnection;
        private readonly string _instruction;

        public MyDbCommand(MyDbConnection dbConnection, string instruction)
        { 
            if (dbConnection == null)
                throw new ArgumentNullException();
            
            if (instruction == null)
                throw new ArgumentNullException();
            
            _dbConnection = dbConnection;

            _instruction = instruction;

        }

        private void Instruction()
        {
            Console.WriteLine("instructions: " + _instruction );
        }

        public void Execute()
        {
            _dbConnection.OpenConnection();
            Instruction();
            _dbConnection.CloseConnection();
        }
        
    }
}