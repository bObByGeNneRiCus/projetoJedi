using System.Collections.Generic;
using System.Net;

namespace Aplicacao.Mensagem.Interface
{
    public interface IMensagemRetorno
    {
        void AdicionarAlerta(string mensagem, HttpStatusCode? httpStatus = null);
        void AdicionarErro(string mensagem, HttpStatusCode? httpStatus = null);
        IEnumerable<string> BuscarErros();
        IEnumerable<string> BuscarAlertas();
        bool PossuiErros();
    }
}
