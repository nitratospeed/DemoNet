using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DemoNet.Infrastructure.Data
{
    public class AppDbContext
    {
        private readonly string _connectionString;

        public AppDbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public SqlConnection Connection()
        {
            try
            {
                SqlConnection connection = new SqlConnection(_connectionString);
                return connection;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
