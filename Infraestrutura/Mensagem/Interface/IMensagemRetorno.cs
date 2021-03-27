using System.Collections.Generic;
using System.Net;

namespace Infraestrutura.Mensagem.Interface
{
    public interface IMensagemRetorno
    {
        bool PossuiErros { get; }
        HttpStatusCode? HttpStatus { get; }
        void AdicionarAlerta(string mensagem, HttpStatusCode? httpStatus = null);
        void AdicionarErro(string mensagem, HttpStatusCode? httpStatus = null);
        IEnumerable<string> BuscarErros();
        IEnumerable<string> BuscarAlertas();
        void SetHttpStatus(HttpStatusCode httpStatus);
    }
}
