using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet_code_challenge.Contexts
{
    /// <summary>
    /// DBContext class responsible for holding connection string
    /// </summary>
    public class DBContext
    {
        private readonly string _connectionString = string.Empty;

        public DBContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string ConnectionString { get { return _connectionString; } }
    }
}
