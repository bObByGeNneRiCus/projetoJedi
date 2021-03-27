using Aplicacao.Modelo.CadastroProduto;
using Aplicacao.Servico.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Controller]
    [Route("cadastros-produto")]
    [AllowAnonymous]
    public class CadastroProdutoController : ControllerBase
    {
        
private readonly ICadastroProdutoService _cadastroProdutoService;

        public CadastroProdutoController(ICadastroProdutoService cadastroProdutoService)
        {
            _cadastroProdutoService = cadastroProdutoService;
        }

        [HttpGet]
        public async Task<IEnumerable<CadastroProdutoModel>> Get()
        {
            var cadastros = await _cadastroProdutoService.BuscarCadastros();
            return cadastros;
        }
        
        [HttpPost]
        public async Task<CadastroProdutoModel> Post([FromBody] CadastroProdutoEnvioModel cadastro)
        {
            var novaCadastro = await _cadastroProdutoService.CriarCadastro(cadastro);
            return novaCadastro;
        }   

         [HttpPut("{idCadastro}")]
        public async Task<CadastroProdutoModel> Put([FromRoute] int idCadastro, [FromBody] CadastroProdutoEnvioModel cadastro)
        {
            var cadastroAtualizada = await _cadastroProdutoService.AtualizarCadastro(idCadastro, cadastro);
            return cadastroAtualizada;
        }

        [HttpDelete("{idCadastro}")]
        public async Task<bool> Delete(int idCadastro)
        {
            var cadastroRemovida = await _cadastroProdutoService.RemoverCadastro(idCadastro);
            return cadastroRemovida;
        }
    }
}