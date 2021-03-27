using Aplicacao.Modelo.CategoriaProduto;
using Aplicacao.Servico.Interface;
using Infraestrutura.Mensagem;
using Infraestrutura.Mensagem.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Controller]
    [Route("categorias-produto")]
    [AllowAnonymous]
    public class CategoriaProdutoController : ApiControllerBase
    {
        private readonly ICategoriaProdutoService _categoriaProdutoService;

        public CategoriaProdutoController(IMensagemRetorno mensagens, ICategoriaProdutoService categoriaProdutoService) : base(mensagens)
        {
            _categoriaProdutoService = categoriaProdutoService;
        }

        [HttpGet]
        public async Task<RetornoApi<IEnumerable<CategoriaProdutoModel>>> Get()
        {
            var categorias = await _categoriaProdutoService.BuscarCategorias();
            return FormatarRetorno(categorias);
        }

        [HttpPost]
        public async Task<RetornoApi<CategoriaProdutoModel>> Post([FromBody] CategoriaProdutoEnvioModel categoria)
        {
            var novaCategoria = await _categoriaProdutoService.CriarCategoria(categoria);
            return FormatarRetorno(novaCategoria);
        }

        [HttpPut("{idCategoria}")]
        public async Task<RetornoApi<CategoriaProdutoModel>> Put([FromRoute] int idCategoria, [FromBody] CategoriaProdutoEnvioModel categoria)
        {
            var categoriaAtualizada = await _categoriaProdutoService.AtualizarCategoria(idCategoria, categoria);
            return FormatarRetorno(categoriaAtualizada);
        }

        [HttpDelete("{idCategoria}")]
        public async Task<RetornoApi<bool>> Delete(int idCategoria)
        {
            var categoriaRemovida = await _categoriaProdutoService.RemoverCategoria(idCategoria);
            return FormatarRetorno(categoriaRemovida);
        }
    }
}
