using Aplicacao.Servico;
using Aplicacao.Servico.Interface;
using Infraestrutura.Repositorio;
using Infraestrutura.Repositorio.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aplicacao.IoC
{
    public static class IoC
    {
        public static IServiceCollection ConfigurarDependencias(this IServiceCollection services)
        {
            services.AddTransient<ICategoriaProdutoService, CategoriaProdutoService>();
            services.AddTransient<ICategoriaProdutoRepositorio, CategoriaProdutoRepositorio>();

            return services;
        }
    }
}
