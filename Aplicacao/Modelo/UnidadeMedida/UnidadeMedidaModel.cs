using Dominio.Etidade;

namespace Aplicacao.Modelo.UnidadeMedida
{
    public class UnidadeMedidaModel
    {
        public string Sigla { get; set; }
        public string Nome { get; set; }

        public UnidadeMedidaModel(UnidadeMedidaDominio dominio)
        {
            Sigla = dominio.Sigla;
            Nome = dominio.Nome;
        }
        
    }
}
