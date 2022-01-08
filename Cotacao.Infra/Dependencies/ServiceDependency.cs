using Cotacao.Domain.Cotacao;
using Cotacao.Domain.CotacaoItem;
using Cotacao.Domain.Shared;
using Cotacao.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cotacao.Infra.Dependencies
{
    public static class ServiceDependency
    {
        public static IServiceCollection AddServicesDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddSingleton(new ConfigurationViewModel(configuration))
                .AddTransient<ICotacaoService, CotacaoService>()
                .AddTransient<ICotacaoItemService, CotacaoItemService>()
                .AddTransient<INotificador, Notificador>();

            return services;
        }
    }
}
