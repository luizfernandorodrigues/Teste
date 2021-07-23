using System.Threading.Tasks;
using Teste.Modelos;

namespace Teste.Servicos
{
    public interface IServicoCep
    {
        Task<CodigoEnderecamentoPostal> ObterCep(int cep);
    }
}
