using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;

namespace Infraestrutura.Repositorio
{
    public abstract class RepositorioBase : IDisposable
    {
        protected readonly IConfiguration _configuration;
        protected readonly SqlConnection _connection;

        public RepositorioBase(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = getConnection();
        }

        private SqlConnection getConnection()
        {
            var connectionString = _configuration.GetSection("ConnectionString")
                                .GetSection("JediConnection").Value;

            return new SqlConnection(connectionString); ;
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
