using Dominio.Entidade;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio.Interface
{
    public interface IUnidadeMedidaRepositorio
    {
        Task<UnidadeMedidaDominio> ObterUnidade(int id);
        Task<IEnumerable<UnidadeMedidaDominio>> BuscarUnidade();
        Task<UnidadeMedidaDominio> GravarUnidade(UnidadeMedidaDominio unidade);
        Task<bool> AtualizarUnidade(int id, UnidadeMedidaDominio unidadeAtualizacao);
        Task<bool> DeletarUnidade(int id);
    }
}
