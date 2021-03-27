using Aplicacao.Mensagem.Interface;
using System.Collections.Generic;
using System.Net;

namespace Aplicacao.Mensagem
{
    public class MensagemRetorno : IMensagemRetorno
    {
        private List<string> Alertas { get; } = new List<string>();
        private List<string> Erros { get; } = new List<string>();
        public HttpStatusCode? HttpStatus { get; private set; }

        public void AdicionarAlerta(string mensagem, HttpStatusCode? httpStatus = null)
        {
            Alertas.Add(mensagem);
            HttpStatus = httpStatus;
        }

        public void AdicionarErro(string mensagem, HttpStatusCode? httpStatus = null)
        {
            Erros.Add(mensagem);
            HttpStatus = httpStatus;
        }

        public IEnumerable<string> BuscarAlertas()
            => Alertas;

        public IEnumerable<string> BuscarErros()
            => Erros;

        public bool PossuiErros()
            => Erros.Count > 0;
    }
}
