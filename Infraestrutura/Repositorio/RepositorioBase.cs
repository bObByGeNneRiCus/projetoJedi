using Infraestrutura.Mensagem.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;

namespace Infraestrutura.Repositorio
{
    public abstract class RepositorioBase : IDisposable
    {
        protected readonly IConfiguration _configuration;
        protected readonly IMensagemRetorno _mensagens;
        protected readonly SqlConnection _connection;

        public RepositorioBase(IConfiguration configuration, IMensagemRetorno mensagens)
        {
            _configuration = configuration;
            _mensagens = mensagens;
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
