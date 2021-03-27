using Infraestrutura.Mensagem.Interface;
using System.Collections.Generic;
using System.Net;

namespace Infraestrutura.Mensagem
{
    public class MensagemRetorno : IMensagemRetorno
    {
        public bool PossuiErros { get => Erros.Count > 0; }
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

        public void SetHttpStatus(HttpStatusCode httpStatus)
            => HttpStatus = httpStatus;
    }
}
