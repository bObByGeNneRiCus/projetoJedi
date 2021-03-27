using Aplicacao.Modelo.CategoriaProduto;
using Aplicacao.Servico.Interface;
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

        public CategoriaProdutoController(ICategoriaProdutoService categoriaProdutoService)
        {
            _categoriaProdutoService = categoriaProdutoService;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoriaProdutoModel>> Get()
        {
            var categorias = await _categoriaProdutoService.BuscarCategorias();
            return categorias;
        }

        [HttpPost]
        public async Task<CategoriaProdutoModel> Post([FromBody] CategoriaProdutoEnvioModel categoria)
        {
            var novaCategoria = await _categoriaProdutoService.CriarCategoria(categoria);
            return novaCategoria;
        }

        [HttpPut("{idCategoria}")]
        public async Task<CategoriaProdutoModel> Put([FromRoute] int idCategoria, [FromBody] CategoriaProdutoEnvioModel categoria)
        {
            var categoriaAtualizada = await _categoriaProdutoService.AtualizarCategoria(idCategoria, categoria);
            return categoriaAtualizada;
        }

        [HttpDelete("{idCategoria}")]
        public async Task<bool> Delete(int idCategoria)
        {
            var categoriaRemovida = await _categoriaProdutoService.RemoverCategoria(idCategoria);
            return categoriaRemovida;
        }
    }
}
