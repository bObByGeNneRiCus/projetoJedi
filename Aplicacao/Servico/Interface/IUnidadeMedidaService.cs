using Aplicacao.Modelo.UnidadeMedida;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Servico.Interface
{
    public interface IUnidadeMedidaService
    {
         Task<IEnumerable<UnidadeMedidaModel>> BuscarUnidadeMedida();
        Task<UnidadeMedidaModel> CriarUnidadeMedida(UnidadeMedidaEnvioModel unidade);
        Task<UnidadeMedidaModel> AtualizarUnidadeMedida(int IDUnidadeMedida, UnidadeMedidaEnvioModel unidade);
        Task<bool> RemoverUnidadeMedida(int IDUnidade);
    }
}

    
  
