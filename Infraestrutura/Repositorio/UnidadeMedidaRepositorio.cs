using Dapper;
using Dominio.Entidade;
using Infraestrutura.Mensagem.Interface;
using Infraestrutura.Repositorio.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public class UnidadeMedidaRepositorio : RepositorioBase, IUnidadeMedidaRepositorio
    {
        public UnidadeMedidaRepositorio(IConfiguration configuration, IMensagemRetorno mensagens) : base(configuration, mensagens) { }

        public async Task<UnidadeMedidaDominio> ObterUnidade(int id)
        {
            UnidadeMedidaDominio unidade = null;
            try
            {
                _connection.Open();
                var query = @"SELECT ID, NOME, DATA_ATUALIZACAO FROM UNIDADE_MEDIDA WHERE ID = @id";

                var parametro = new DynamicParameters();
                parametro.Add("id", id);

                unidade = await _connection.QueryFirstOrDefaultAsync<UnidadeMedidaDominio>(query, parametro);
            }
            catch (Exception ex)
            {
                _mensagens.AdicionarErro($"Ocorreu um erro ao obter a unidade id {id}. Detalhes: {ex.Message}", HttpStatusCode.InternalServerError);
            }
            finally
            {
                _connection.Close();
            }

            return unidade;
        }

        public async Task<IEnumerable<UnidadeMedidaDominio>> BuscarUnidades()
        {
            // Apenas cria uma lista para ser utilizada para retorno das categorias
            IEnumerable<UnidadeMedidaDominio> unidades = null;
            try
            {
                // Abre a conexão com o banco de dados
                _connection.Open();
                // Cria uma variável, colocando dentro dela a string SQL da consulta no banco de dados
                var query = @"SELECT ID, NOME, DATA_ATUALIZACAO FROM UNIDADE_MEDIDA";
                // _connection.QueryAsync executa a nossa consulta no banco de dados. Observer que a variável que criamos acima agora é passada como parâmetro
                unidades = await _connection.QueryAsync<UnidadeMedidaDominio>(query);
            }
            catch (Exception ex)
            {
                _mensagens.AdicionarErro($"Ocorreu um erro ao buscar as unidades. Detalhes: {ex.Message}", HttpStatusCode.InternalServerError);
            }
            finally
            {
                // Fecha a conexão com o banco de dados
                _connection.Close();
            }

            return unidades;
        }

        public async Task<UnidadeMedidaDominio> GravarUnidade(UnidadeMedidaDominio unidade)
        {
            UnidadeMedidaDominio novaUnidade = null;
            try
            {
                _connection.Open();
                var query = @"INSERT INTO UNIDADE_MEDIDA (NOME, DATA_ATUALIZACAO) VALUES (@nome, @dataAtualizacao); 
                                SELECT ID, NOME, DATA_ATUALIZACAO FROM UNIDADE_MEDIDA WHERE ID = CAST(SCOPE_IDENTITY() as INT);";
                // _connection.QueryFirstAsync (first == primeiro em inglês) retorna somente o primeiro registro de uma consulta
                novaUnidade = await _connection.QueryFirstAsync<UnidadeMedidaDominio>(query, unidade);
            }
            catch (Exception ex)
            {
                _mensagens.AdicionarErro($"Ocorreu um erro ao gravar a unidade de produto {unidade.Nome}. Detalhes: {ex.Message}", HttpStatusCode.InternalServerError);
            }
            finally
            {
                _connection.Close();
            }

            return novaUnidade;
        }

        public async Task<bool> AtualizarUnidade(int id, UnidadeMedidaDominio unidadeAtualizacao)
        {
            var registrosAtualizados = 0;
            try
            {
                _connection.Open();
                var query = @"UPDATE UNIDADE_MEDIDA SET NOME = @nome, DATA_ATUALIZACAO = @dataAtualizacao WHERE ID = @id";

                var parametros = new DynamicParameters();
                parametros.Add("id", id);
                parametros.Add("nome", unidadeAtualizacao.Nome);
                parametros.Add("dataAtualizacao", unidadeAtualizacao.DataAtualizacao);

                // _connection.ExecuteAsync apenas executa o comando SQL que passamos, e retorna a quantidade de registro que afetou
                registrosAtualizados = await _connection.ExecuteAsync(query, parametros);

                if (registrosAtualizados == 0)
                    _mensagens.AdicionarErro($"Nenhum registro pôde ser atualizado.", HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                _mensagens.AdicionarErro($"Ocorreu um erro ao atualizar a unidade id {id}. Detalhes: {ex.Message}", HttpStatusCode.InternalServerError);
            }
            finally
            {
                _connection.Close();
            }

            return registrosAtualizados == 1;
        }

        public async Task<bool> DeletarUnidade(int id)
        {
            var registrosDeletados = 0;
            try
            {
                _connection.Open();
                var query = @"DELETE FROM UNIDADE_MEDIDA WHERE ID = @id";

                var parametro = new DynamicParameters();
                parametro.Add("id", id);

                registrosDeletados = await _connection.ExecuteAsync(query, parametro);

                if (registrosDeletados == 0)
                    _mensagens.AdicionarErro($"Nenhum registro pôde ser deletado.", HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                _mensagens.AdicionarErro($"Ocorreu um erro ao deletar a unidade id {id}. Detalhes: {ex.Message}", HttpStatusCode.InternalServerError);
            }
            finally
            {
                _connection.Close();
            }

            return registrosDeletados == 1;
        }
    }
}
