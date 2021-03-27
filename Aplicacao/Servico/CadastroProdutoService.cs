using Aplicacao.Modelo.CadastroProduto;
using Aplicacao.Servico.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Aplicacao.Servico
{
     public class CadastroProdutoService : ICadastroProdutoService
    {
        public async Task<IEnumerable<CadastroProdutoModel>> BuscarCadastros()
        {
            throw new NotImplementedException();
        }

        public async Task<CadastroProdutoModel> CriarCadastro(CadastroProdutoEnvioModel cadastro)
        {
            throw new NotImplementedException();
        }

        public async Task<CadastroProdutoModel> AtualizarCadastro(int idCadastro, CadastroProdutoEnvioModel cadastro)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoverCadastro(int idCadastro)
        {
            throw new NotImplementedException();
        }
    }
}