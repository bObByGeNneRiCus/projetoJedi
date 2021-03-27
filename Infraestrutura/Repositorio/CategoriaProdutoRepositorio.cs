using Dapper;
using Dominio.Entidade;
using Infraestrutura.Repositorio.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public class CategoriaProdutoRepositorio : RepositorioBase, ICategoriaProdutoRepositorio
    {
        public CategoriaProdutoRepositorio(IConfiguration configuration) : base(configuration) { }

        public async Task<CategoriaProdutoDominio> ObterCategoria(int id)
        {
            CategoriaProdutoDominio categoria;
            try
            {
                _connection.Open();
                var query = @"SELECT ID, NOME, DATA_ATUALIZACAO FROM CATEGORIA_PRODUTO WHERE ID = @id";

                var parametro = new DynamicParameters();
                parametro.Add("id", id);

                categoria = await _connection.QueryFirstOrDefaultAsync<CategoriaProdutoDominio>(query, parametro);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao obter a categoria id {id}. Detalhes: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }

            return categoria;
        }

        public async Task<IEnumerable<CategoriaProdutoDominio>> BuscarCategorias()
        {
            // Apenas cria uma lista para ser utilizada para retorno das categorias
            IEnumerable<CategoriaProdutoDominio> categorias;
            try
            {
                // Abre a conexão com o banco de dados
                _connection.Open();
                // Cria uma variável, colocando dentro dela a string SQL da consulta no banco de dados
                var query = @"SELECT ID, NOME, DATA_ATUALIZACAO FROM CATEGORIA_PRODUTO";
                // _connection.QueryAsync executa a nossa consulta no banco de dados. Observer que a variável que criamos acima agora é passada como parâmetro
                categorias = await _connection.QueryAsync<CategoriaProdutoDominio>(query);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao buscar as categorias. Detalhes: {ex.Message}");
            }
            finally
            {
                // Fecha a conexão com o banco de dados
                _connection.Close();
            }

            return categorias;
        }

        public async Task<CategoriaProdutoDominio> GravarGategoria(CategoriaProdutoDominio categoria)
        {
            CategoriaProdutoDominio novaCategoria;
            try
            {
                _connection.Open();
                var query = @"INSERT INTO CATEGORIA_PRODUTO (NOME, DATA_ATUALIZACAO) VALUES (@nome, @dataAtualizacao); 
                                SELECT ID, NOME, DATA_ATUALIZACAO FROM CATEGORIA_PRODUTO WHERE ID = CAST(SCOPE_IDENTITY() as INT);";
                // _connection.QueryFirstAsync (first == primeiro em inglês) retorna somente o primeiro registro de uma consulta
                novaCategoria = await _connection.QueryFirstAsync<CategoriaProdutoDominio>(query, categoria);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao gravar a categoria de produto {categoria.Nome}. Detalhes: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }

            return novaCategoria;
        }

        public async Task<bool> AtualizarGategoria(int id, CategoriaProdutoDominio categoriaAtualizacao)
        {
            var registrosAtualizados = 0;
            try
            {
                _connection.Open();
                var query = @"UPDATE CATEGORIA_PRODUTO SET NOME = @nome, DATA_ATUALIZACAO = @dataAtualizacao WHERE ID = @id";

                var parametros = new DynamicParameters();
                parametros.Add("id", id);
                parametros.Add("nome", categoriaAtualizacao.Nome);
                parametros.Add("dataAtualizacao", categoriaAtualizacao.DataAtualizacao);

                // _connection.ExecuteAsync apenas executa o comando SQL que passamos, e retorna a quantidade de registro que afetou
                registrosAtualizados = await _connection.ExecuteAsync(query, parametros);

                if (registrosAtualizados == 0)
                    throw new Exception($"Nenhum registro pôde ser atualizado.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao atualizar a categoria id {id}. Detalhes: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }

            return registrosAtualizados == 1;
        }

        public async Task<bool> DeletarGategoria(int id)
        {
            var registrosDeletados = 0;
            try
            {
                _connection.Open();
                var query = @"DELETE FROM CATEGORIA_PRODUTO WHERE ID = @id";

                var parametro = new DynamicParameters();
                parametro.Add("id", id);

                registrosDeletados = await _connection.ExecuteAsync(query, parametro);

                if (registrosDeletados == 0)
                    throw new Exception($"Nenhum registro pôde ser deletado.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao deletar a categoria id {id}. Detalhes: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }

            return registrosDeletados == 1;
        }
    }
}
