using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace DesafioBackend.Data
{
    public class DapperDbContext
    {
        private readonly string _connectionString = string.Empty;

        public DapperDbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Database");
        }

        public IDbConnection DapperConnection
        {
            get
            {
                return new NpgsqlConnection(_connectionString);
            }
        }
    }
}