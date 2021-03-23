using Aplicacao.Modelo.CadastroProduto;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Aplicacao.Servico.Interface
{
    public interface ICadastroProdutoService
    {
        Task<IEnumerable<CadastroProdutoModel>> BuscarCadastros();
        Task<CadastroProdutoModel> CriarCadastro(CadastroProdutoEnvioModel cadastro);
        Task<CadastroProdutoModel> AtualizarCadastro(int idCadastro, CadastroProdutoEnvioModel cadastro);
        Task<bool> RemoverCadastro(int idCadastro);
    }
}