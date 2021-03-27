using Dominio.Entidade;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio.Interface
{
    public interface ICategoriaProdutoRepositorio
    {
        Task<CategoriaProdutoDominio> ObterCategoria(int id);
        Task<IEnumerable<CategoriaProdutoDominio>> BuscarCategorias();
        Task<CategoriaProdutoDominio> GravarGategoria(CategoriaProdutoDominio categoria);
        Task<bool> AtualizarGategoria(int id, CategoriaProdutoDominio categoriaAtualizacao);
        Task<bool> DeletarGategoria(int id);
    }
}
