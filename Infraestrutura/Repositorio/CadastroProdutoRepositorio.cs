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
    public class CadastroProdutoRepositorio : RepositorioBase, ICadastroProdutoRepositorio
    {
        public CadastroProdutoRepositorio(IConfiguration configuration, IMensagemRetorno mensagens) : base(configuration, mensagens) { }

        public async Task<CadastroProdutoDominio> ObterCadastro(int id)
        {
            CadastroProdutoDominio cadastro = null;
            try
            {
                _connection.Open();
                var query = @"SELECT ID, NOME, DATA_ATUALIZACAO FROM CADASTRO_PRODUTO WHERE ID = @id";

                var parametro = new DynamicParameters();
                parametro.Add("id", id);

                cadastro = await _connection.QueryFirstOrDefaultAsync<CadastroProdutoDominio>(query, parametro);
            }
            catch (Exception ex)
            {
                _mensagens.AdicionarErro($"Ocorreu um erro ao obter o cadastro id {id}. Detalhes: {ex.Message}", HttpStatusCode.InternalServerError);
            }
            finally
            {
                _connection.Close();
            }

            return cadastro;
        }

        public async Task<IEnumerable<CadastroProdutoDominio>> BuscarCadastros()
        {
            
            IEnumerable<CadastroProdutoDominio> cadastros = null;
            try
            {
                _connection.Open();
                // Cria uma variável, colocando dentro dela a string SQL da consulta no banco de dados
                var query = @"SELECT ID, NOME, DATA_ATUALIZACAO FROM CADASTRO_PRODUTO";
                // _connection.QueryAsync executa a nossa consulta no banco de dados. Observer que a variável que criamos acima agora é passada como parâmetro
                cadastros = await _connection.QueryAsync<CadastroProdutoDominio>(query);
            }
            catch (Exception ex)
            {
                _mensagens.AdicionarErro($"Ocorreu um erro ao buscar os cadastros. Detalhes: {ex.Message}", HttpStatusCode.InternalServerError);
            }
            finally
            {
                // Fecha a conexão com o banco de dados
                _connection.Close();
            }

            return cadastros;
        }

        public async Task<CadastroProdutoDominio> GravarCadastro(CadastroProdutoDominio cadastro)
        {
            CadastroProdutoDominio novoCadastro = null;
            try
            {
                _connection.Open();
                var query = @"INSERT INTO CADASTRO_PRODUTO (NOME, DATA_ATUALIZACAO) VALUES (@nome, @dataAtualizacao); 
                                SELECT ID, NOME, DATA_ATUALIZACAO FROM CADASTRO_PRODUTO WHERE ID = CAST(SCOPE_IDENTITY() as INT);";
                // _connection.QueryFirstAsync (first == primeiro em inglês) retorna somente o primeiro registro de uma consulta
                novoCadastro = await _connection.QueryFirstAsync<CadastroProdutoDominio>(query, cadastro);
            }
            catch (Exception ex)
            {
                _mensagens.AdicionarErro($"Ocorreu um erro ao gravar o cadastro de produto {cadastrotegoria.Nome}. Detalhes: {ex.Message}", HttpStatusCode.InternalServerError);
            }
            finally
            {
                _connection.Close();
            }

            return novoCadastro;
        }

        public async Task<bool> AtualizarCadastro(int id, CadastroProdutoDominio cadastroAtualizacao)
        {
            var registrosAtualizados = 0;
            try
            {
                _connection.Open();
                var query = @"UPDATE CADASTRO_PRODUTO SET NOME = @nome, DATA_ATUALIZACAO = @dataAtualizacao WHERE ID = @id";

                var parametros = new DynamicParameters();
                parametros.Add("id", id);
                parametros.Add("nome", cadastroAtualizacao.Nome);
                parametros.Add("dataAtualizacao", cadastroAtualizacao.DataAtualizacao);

                // _connection.ExecuteAsync apenas executa o comando SQL que passamos, e retorna a quantidade de registro que afetou
                registrosAtualizados = await _connection.ExecuteAsync(query, parametros);

                if (registrosAtualizados == 0)
                    _mensagens.AdicionarErro($"Nenhum registro pôde ser atualizado.", HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                _mensagens.AdicionarErro($"Ocorreu um erro ao atualizar o cadastro id {id}. Detalhes: {ex.Message}", HttpStatusCode.InternalServerError);
            }
            finally
            {
                _connection.Close();
            }

            return registrosAtualizados == 1;
        }

        public async Task<bool> DeletarCadastro(int id)
        {
            var registrosDeletados = 0;
            try
            {
                _connection.Open();
                var query = @"DELETE FROM CADASTRO_PRODUTO WHERE ID = @id";

                var parametro = new DynamicParameters();
                parametro.Add("id", id);

                registrosDeletados = await _connection.ExecuteAsync(query, parametro);

                if (registrosDeletados == 0)
                    _mensagens.AdicionarErro($"Nenhum registro pôde ser deletado.", HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                _mensagens.AdicionarErro($"Ocorreu um erro ao deletar o cadastro id {id}. Detalhes: {ex.Message}", HttpStatusCode.InternalServerError);
            }
            finally
            {
                _connection.Close();
            }

            return registrosDeletados == 1;
        }
    }
}