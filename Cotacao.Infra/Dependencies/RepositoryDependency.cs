using Cotacao.Domain.Cotacao;
using Cotacao.Domain.CotacaoItem;
using Cotacao.Infra.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cotacao.Infra.Dependencies
{
    public static class RepositoryDependency
    {
        public static IServiceCollection AddRepositoriesDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddTransient<ICotacaoRepository>(r => new CotacaoRepository(configuration.GetConnectionString("Cotacao")))
                .AddTransient<ICotacaoItemRepository>(r => new CotacaoItemRepository(configuration.GetConnectionString("Cotacao")));


            return services;
        }
    }
}
