using System.Collections.Generic;
using System.Net;

namespace Aplicacao.Mensagem
{
    public interface IMensagemRetorno
    {
        public IEnumerable<string> Alertas { get; set; }
        public IEnumerable<string> Erros { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        void AdicionarAlerta(string mensagem);
        void AdicionarErro(string mensagem);
        IEnumerable<string> BuscarErros();
        IEnumerable<string> BuscarAlertas();
        bool PossuiErros();
    }
}
