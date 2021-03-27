using Aplicacao.Modelo.UnidadeMedida;
using Aplicacao.Servico.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Controller]
    [Route("unidade-medida")]
    [AllowAnonymous]
    public class UnidadeMedidaController : ControllerBase
    {
        private readonly IUnidadeMedidaService _unidadeMedidaService;

        public UnidadeMedidaController(IUnidadeMedidaService unidadeMedidaService)
        {
            _unidadeMedidaService = unidadeMedidaService;
        }

        [HttpGet]
        public async Task<IEnumerable<UnidadeMedidaModel>> Get()
        {
            var unidades = await _unidadeMedidaService.BuscarUnidadeMedida();
            return unidades;
        }

        [HttpPost]
        public async Task<UnidadeMedidaModel> Post([FromBody] UnidadeMedidaEnvioModel unidade)
        {
            var novaUnidade = await _unidadeMedidaService.CriarUnidadeMedida(unidade);
            return novaUnidade;
        }

        [HttpPut("{idUnidade}")]
        public async Task<UnidadeMedidaModel> Put([FromRoute] int idUnidade, [FromBody] UnidadeMedidaEnvioModel unidade)
        {
            var unidadeAtualizada = await _unidadeMedidaService.AtualizarUnidadeMedida(idUnidade, unidade);
            return unidadeAtualizada;
        }

        [HttpDelete("{idUnidade}")]
        public async Task<bool> Delete([FromRoute] int idUnidade)
        {
            var unidadeRemovida = await _unidadeMedidaService.RemoverUnidadeMedida(idUnidade);
            return unidadeRemovida;
        }
    }
}