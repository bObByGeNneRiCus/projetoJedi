namespace Dominio.Etidade
{
    public class UnidadeMedidaDominio: EntidadeBase
    {
        public string Nome { get; private set; }
        public string Sigla { get; private set; }

        public UnidadeMedidaDominio(string nome, string sigla)
        {
            Nome = nome;
            Sigla = sigla;
        }

        public void AtualizarUnidadeMedida(string nome, string sigla)
        {
            Nome = nome;
            Sigla = sigla;

            SetDataAtualizacao();
        }
    }
}