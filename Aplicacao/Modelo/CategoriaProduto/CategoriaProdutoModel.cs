using Dominio.Entidade;

namespace Aplicacao.Modelo.CategoriaProduto
{
    public class CategoriaProdutoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public CategoriaProdutoModel(CategoriaProdutoDominio dominio)
        {
            if (dominio == null)
                dominio = new CategoriaProdutoDominio();

            Id = dominio.Id;
            Nome = dominio.Nome;
        }
    }
}
