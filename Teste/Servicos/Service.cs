using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Teste.Servicos
{
    public abstract class Service
    {
        /// <summary>
        /// Método responsavel por deserializar o retorno da consulta na api
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="responseMessage"></param>
        /// <returns></returns>
        protected async Task<T> DeserializaObjetoResponse<T>(HttpResponseMessage responseMessage)
        {
            /// configura as opções de propriedade do objeto que irá receber o retorno
            var opcoes = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<T>(await responseMessage.Content.ReadAsStringAsync(), opcoes);
        }
    }
}
