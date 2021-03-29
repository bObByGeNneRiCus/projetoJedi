using Dominio.Entidade;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio.Interface
{
    public interface ICadastroProdutoRepositorio
    {
        Task<CadastroProdutoDominio> ObterCadastro(int id);
        Task<IEnumerable<CadastroProdutoDominio>> BuscarCadastros();
        Task<CadastroProdutoDominio> GravarCadastro(CadastroProdutoDominio cadastro);
        Task<bool> AtualizarCadastro(int id, CadastroProdutoDominio cadastroAtualizacao);
        Task<bool> DeletarCadastro(int id);
    }
}