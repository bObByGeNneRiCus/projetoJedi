using Aplicacao.Modelo.CategoriaProduto;
using Aplicacao.Servico.Interface;
using Dominio.Entidade;
using Infraestrutura.Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Servico
{
    public class CategoriaProdutoService : ICategoriaProdutoService
    {
        private readonly ICategoriaProdutoRepositorio _categoriaProdutoRepositorio;

        public CategoriaProdutoService(ICategoriaProdutoRepositorio categoriaProdutoRepositorio)
            => _categoriaProdutoRepositorio = categoriaProdutoRepositorio;

        public async Task<IEnumerable<CategoriaProdutoModel>> BuscarCategorias()
        {
            var categorias = await _categoriaProdutoRepositorio.BuscarCategorias();

            return categorias.Select(categoria => new CategoriaProdutoModel(categoria));
        }

        public async Task<CategoriaProdutoModel> CriarCategoria(CategoriaProdutoEnvioModel categoria)
        {
            var categoriaProduto = new CategoriaProdutoDominio(categoria.Nome);
            var novaCategoria = await _categoriaProdutoRepositorio.GravarGategoria(categoriaProduto);

            return new CategoriaProdutoModel(novaCategoria);
        }

        public async Task<CategoriaProdutoModel> AtualizarCategoria(int idCategoria, CategoriaProdutoEnvioModel categoriaAtualizacao)
        {
            //Pra atualizar, primeiro verificamos se o registro realmente já existe no banco. Não há como atualizar algo que sequer existe
            var categoria = await _categoriaProdutoRepositorio.ObterCategoria(idCategoria);

            if (categoria == null)
                throw new Exception($"Nenhum registro localizado com id {idCategoria}.");

            categoria.AtualizarCategoria(categoriaAtualizacao.Nome);

            await _categoriaProdutoRepositorio.AtualizarGategoria(idCategoria, categoria);

            return new CategoriaProdutoModel(categoria);
        }

        public async Task<bool> RemoverCategoria(int idCategoria)
        {
            var categoria = await _categoriaProdutoRepositorio.ObterCategoria(idCategoria);

            if (categoria == null)
                throw new Exception($"Nenhum registro localizado com id {idCategoria}.");

            return await _categoriaProdutoRepositorio.DeletarGategoria(idCategoria);
        }
    }
}
