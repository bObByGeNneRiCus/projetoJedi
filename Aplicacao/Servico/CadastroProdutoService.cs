using Aplicacao.Modelo.CadastroProduto;
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
     public class CadastroProdutoService : ServicoBase, ICadastroProdutoService
    {
        private readonly ICadastroProdutoRepositorio _cadastroProdutoRepositorio;

        public CadastroProdutoService(IMensagemRetorno mensagens, ICadastroProdutoRepositorio cadastroProdutoRepositorio) : base(mensagens)
            => _cadastroProdutoRepositorio = cadastroProdutoRepositorio;

        public async Task<IEnumerable<CadastroProdutoModel>> BuscarCadastros()
        {
            var cadastros = await _cadastroProdutoRepositorio.BuscarCadastros();

            return cadastros.Select(cadastro => new CadastroProdutoModel(cadastro));
        }
        public async Task<CadastroProdutoModel> CriarCadastro(CadastroProdutoEnvioModel cadastro)
        {
            var cadastroProduto = new CadastroProdutoDominio(cadastro.Nome);
            var novoCadastro = await _cadastroProdutoRepositorio.GravarCadastro(cadastroProduto);
            _mensagens.SetHttpStatus(HttpStatusCode.Created);

            return new CadastroProdutoModel(novoCadastro);
        }

        public async Task<CadastroProdutoModel> AtualizarCadastro(int idCadastro, CadastroProdutoEnvioModel cadastroAtualizacao)
        {
            var cadastro = await _cadastroProdutoRepositorio.ObterCadastro(idCadastro);

            if (cadastro == null)
            {
                _mensagens.AdicionarAlerta($"Nenhum registro localizado com id {idCadastro}.", HttpStatusCode.NotFound);
                return null;
            }

            cadastro.AtualizarCadastro(cadastroAtualizacao.Nome);

            await _cadastroProdutoRepositorio.AtualizarCadastro(idCadastro, cadastro);

            return new CadastroProdutoModel(cadastro);
        }

        public async Task<bool> RemoverCadastro(int idCadastro)
        {
            var cadastro = await _cadastroProdutoRepositorio.ObterCadastro(idCadastro);

            if (cadastro == null)
            {
                _mensagens.AdicionarAlerta($"Nenhum registro localizado com id {idCadastro}.", HttpStatusCode.NotFound);
                return false;
            }

            return await _cadastroProdutoRepositorio.Deletarcadastro(idCadastro);
        }
    }
}