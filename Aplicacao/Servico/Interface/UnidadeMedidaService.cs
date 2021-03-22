using Aplicacao.Modelo.UnidadeMedida;
using Aplicacao.Servico.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Servico
{
    public class UnidadeMedidaService : IUnidadeMedidaService
    {
         public async Task<IEnumerable<UnidadeMedidaModel>> BuscarUnidadeMedida()
        {
            throw new NotImplementedException();
        }

        public async Task<UnidadeMedidaModel> CriarUnidadeMedida(UnidadeMedidaEnvioModel unidade)
        {
            throw new NotImplementedException();
        }

        public async Task<UnidadeMedidaModel> AtualizarUnidadeMedida(int IDUnidadeMedida, UnidadeMedidaModel unidade)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoverUnidadeMedida(int IDUnidade)
        {
            throw new NotImplementedException();
        }
        
    }
}