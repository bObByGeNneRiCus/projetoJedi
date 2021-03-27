﻿using Aplicacao.Servico;
using Aplicacao.Servico.Interface;
using Infraestrutura.Mensagem;
using Infraestrutura.Mensagem.Interface;
using Infraestrutura.Repositorio;
using Infraestrutura.Repositorio.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Aplicacao.IoC
{
    public static class IoC
    {
        public static IServiceCollection ConfigurarDependencias(this IServiceCollection services)
        {
            services.AddTransient<ICategoriaProdutoService, CategoriaProdutoService>();
            services.AddTransient<ICadastroProdutoService, CadastroProdutoService>();
            services.AddTransient<IUnidadeMedidaService, UnidadeMedidaService>();
            services.AddTransient<ICategoriaProdutoRepositorio, CategoriaProdutoRepositorio>();
            services.AddScoped<IMensagemRetorno, MensagemRetorno>();

            return services;
        }
    }
}
