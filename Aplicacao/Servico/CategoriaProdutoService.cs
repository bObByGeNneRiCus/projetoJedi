using Aplicacao.Modelo.CategoriaProduto;
using Aplicacao.Servico.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Servico
{
    public class CategoriaProdutoService : ICategoriaProdutoService
    {
        public async Task<IEnumerable<CategoriaProdutoModel>> BuscarCategorias()
        {
            throw new NotImplementedException();
        }

        public async Task<CategoriaProdutoModel> CriarCategoria(CategoriaProdutoEnvioModel categoria)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoriaProdutoModel> AtualizarCategoria(int idCategoria, CategoriaProdutoEnvioModel categoria)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoverCategoria(int idCategoria)
        {
            throw new NotImplementedException();
        }
    }
}
