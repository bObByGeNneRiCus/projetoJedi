using Aplicacao.Modelo.UnidadeMedida;
using Aplicacao.Servico.Interface;
using Dominio.Entidade;
using Infraestrutura.Mensagem.Interface;
using Infraestrutura.Repositorio.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Aplicacao.Servico
{
    public class UnidadeMedidaService : ServicoBase, IUnidadeMedidaService
        {
            private readonly IUnidadeMedidaRepositorio _unidadeMedidaRepositorio;
            UnidadeMedidaService(IMensagemRetorno mensagens, IUnidadeMedidaRepositorio unidadeMedidaRepositorio) : base(mensagens)
            => _unidadeMedidaRepositorio = unidadeMedidaRepositorio;

        public async Task<IEnumerable<UnidadeMedidaModel>> BuscarUnidadeMedida()
        {
            var unidades = await _unidadeMedidaRepositorio.BuscarUnidades();

            return unidades.Select(unidade => new UnidadeMedidaModel(unidade));
        }

        public async Task<UnidadeMedidaModel> CriarUnidadeMedida(UnidadeMedidaEnvioModel unidade)
        {
           var unidadeMedida = new UnidadeMedidaDominio(unidade.Nome);
            var novaUnidade = await _unidadeMedidaRepositorio.GravarUnidade(unidadeMedida);
            _mensagens.SetHttpStatus(HttpStatusCode.Created);

            return new UnidadeMedidaModel(novaUnidade);
        }
        
        public async Task<UnidadeMedidaModel> AtualizarUnidade(int idUnidade, UnidadeMedidaEnvioModel unidadeAtualizacao)
        {
            var unidade = await _unidadeMedidaRepositorio.ObterUnidade(idUnidade);

            if (unidade == null)
            {
                _mensagens.AdicionarAlerta($"Nenhum registro localizado com id {idUnidade}.", HttpStatusCode.NotFound);
                return null;
            }

            unidade.AtualizarUnidade(unidadeAtualizacao.Nome);

            await _unidadeMedidaRepositorio.AtualizarUnidade(idUnidade, unidade);

            return new UnidadeMedidaModel(unidade);
        }
        
        public async Task<bool> RemoverUnidade(int idUnidade)
        {
            var unidade = await _unidadeMedidaRepositorio.ObterCategoria(idUnidade);

            if (unidade == null)
            {
                _mensagens.AdicionarAlerta($"Nenhum registro localizado com id {idUnidade}.", HttpStatusCode.NotFound);
                return false;
            }

            return await _unidadeMedidaRepositorio.DeletarGategoria(idUnidade);
        }        
    }
}