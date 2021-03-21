using Dominio.Etidade;

namespace Aplicacao.Modelo.CategoriaProduto
{
    public class CategoriaProdutoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public CategoriaProdutoModel(CategoriaProdutoDominio dominio)
        {
            Id = dominio.Id;
            Nome = dominio.Nome;
        }
    }
}
