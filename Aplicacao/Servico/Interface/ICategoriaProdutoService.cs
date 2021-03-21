using Aplicacao.Modelo.CategoriaProduto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Servico.Interface
{
    public interface ICategoriaProdutoService
    {
        Task<IEnumerable<CategoriaProdutoModel>> BuscarCategorias();
        Task<CategoriaProdutoModel> CriarCategoria(CategoriaProdutoEnvioModel categoria);
        Task<CategoriaProdutoModel> AtualizarCategoria(int idCategoria, CategoriaProdutoEnvioModel categoria);
        Task<bool> RemoverCategoria(int idCategoria);
    }
}
