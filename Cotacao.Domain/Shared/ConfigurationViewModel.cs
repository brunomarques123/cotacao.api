using Microsoft.Extensions.Configuration;

namespace Cotacao.Domain.Shared
{
    public class ConfigurationViewModel
    {
        public ConfigurationViewModel(IConfiguration configuration)
        {
            configuration.GetSection("Configuracao").Bind(this);
        }

        public string AuthValue { get; set; }
        public string Ambiente { get; set; }
        public string Versao { get; set; }
    }
}
