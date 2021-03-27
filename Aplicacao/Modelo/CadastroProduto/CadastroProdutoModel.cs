using Dominio.Etidade;

namespace Aplicacao.Modelo.CadastroProduto
{
    public class CadastroProdutoModel
    {
        public string Nome { get; set; }

        public CadastroProdutoModel(CadastroProdutoDominio dominio)
        {
            Nome = dominio.Nome;
        }
    }
}