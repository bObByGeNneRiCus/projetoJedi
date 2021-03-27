using Infraestrutura.Mensagem.Interface;

namespace Aplicacao.Servico
{
    public abstract class ServicoBase
    {
        protected readonly IMensagemRetorno _mensagens;

        public ServicoBase(IMensagemRetorno mensagens)
            => _mensagens = mensagens;
    }
}
