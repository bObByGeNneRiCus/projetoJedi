namespace Dominio.Etidade
{
    public class CadastroProdutoDominio
    {
        public string Nome { get; private set; }

        public CadastroProdutoDominio(string nome)
            => Nome = nome;

        public void AtualizarCadastro(string nome)
            => Nome = nome;
    }
}