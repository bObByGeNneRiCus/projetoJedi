using System.Collections.Generic;

namespace Infraestrutura.Mensagem
{
    public class RetornoApi<T>
    {
        public object Retorno { get; set; }
        public IEnumerable<string> Alertas { get; set; }
        public IEnumerable<string> Erros { get; set; }
    }
}
