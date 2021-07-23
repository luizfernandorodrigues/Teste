using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Teste.Modelos;
using Teste.Servicos;

namespace Teste.Configuracoes
{
    public static class ConfiguraInjecaoDependencia
    {
        /// <summary>
        /// Configura as injeções de dependencia do projeto, repositorios, serviços e etc
        /// </summary>
        /// <param name="servicos"></param>
        public static void RegistraServicos(this IServiceCollection servicos, IConfiguration configuracao)
        {
            servicos.Configure<AppSettingsAPI>(configuracao);
            servicos.AddHttpClient<IServicoCep, ServicoCep>();
        }
    }
}
