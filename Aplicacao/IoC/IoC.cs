using Aplicacao.Servico;
using Aplicacao.Servico.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Aplicacao.IoC
{
    public static class IoC
    {
        public static IServiceCollection ConfigurarDependencias(this IServiceCollection services)
        {
            services.AddTransient<ICategoriaProdutoService, CategoriaProdutoService>();
            services.AddTransient<ICadastroProdutoService, CadastroProdutoService>();

            return services;
        }
    }
}
