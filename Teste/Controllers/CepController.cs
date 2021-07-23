using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Teste.Servicos;

namespace Teste.Controllers
{
    public class CepController : AController
    {
        private readonly IServicoCep _servicoCep;

        /// <summary>
        /// injeta o serviço por meio de injeção de dependencia
        /// </summary>
        /// <param name="servicoCep"></param>
        public CepController(IServicoCep servicoCep)
        {
            _servicoCep = servicoCep;
        }

        [HttpGet]
        [Route("obter-cep/{cep:int}")]
        public async Task<IActionResult> ObterCep(int cep)
        {
            try
            {
                var resposta = await _servicoCep.ObterCep(cep);

                return CustomResponse(resposta);
            }
            catch (Exception ex)
            {
                return CustomResponse(ex.Message);
            }
        }
    }
}
