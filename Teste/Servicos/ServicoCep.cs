using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Teste.Modelos;

namespace Teste.Servicos
{
    public class ServicoCep : Service, IServicoCep
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// configura o baseurl na instancia de httpclient que foi instanciado pelo container de DI do .net core
        /// a url será informada no arquivo de configuração que será construido de acordo com o ambiente de execução
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="settings"></param>
        public ServicoCep(HttpClient httpClient, IOptions<AppSettingsAPI> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.UrlViaCep);
        }

        /// <summary>
        /// realiza o get assincrono na api de cep e retorna uma task do tipo CodigoEnderecamentoPostal
        /// </summary>
        /// <param name="cep"></param>
        /// <returns></returns>
        public async Task<CodigoEnderecamentoPostal> ObterCep(int cep)
        {
            var resposta = await _httpClient.GetAsync($"/ws/{cep}/json/");

            return await DeserializaObjetoResponse<CodigoEnderecamentoPostal>(resposta);
        }
    }
}
