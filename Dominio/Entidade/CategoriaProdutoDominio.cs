namespace Dominio.Entidade
{
    public class CategoriaProdutoDominio : EntidadeBase
    {
        public string Nome { get; private set; }

        public CategoriaProdutoDominio(string nome)
            => Nome = nome;

        public void AtualizarCategoria(string nome)
        {
            Nome = nome;

            SetDataAtualizacao();
        }
    }
}
