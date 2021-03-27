using Infraestrutura.Mensagem;
using Infraestrutura.Mensagem.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    public class ApiControllerBase : ControllerBase
    {
        private readonly IMensagemRetorno _mensagens;

        public ApiControllerBase(IMensagemRetorno mensagens)
            => _mensagens = mensagens;

        public RetornoApi<T> FormatarRetorno<T>(T retorno)
        {
            var retornoApi = new RetornoApi<T>
            {
                Retorno = retorno,
                Alertas = _mensagens.BuscarAlertas(),
                Erros = _mensagens.BuscarErros()
            };

            HttpContext.Response.StatusCode = obterStatusCode();

            return retornoApi;
        }

        private int obterStatusCode()
        {
            if (_mensagens.HttpStatus.HasValue)
                return (int)_mensagens.HttpStatus.Value;
            else if (_mensagens.PossuiErros)
                return (int)HttpStatusCode.BadRequest;

            return (int)HttpStatusCode.OK;
        }
    }
}
