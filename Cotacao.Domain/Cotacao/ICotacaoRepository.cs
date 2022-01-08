using Cotacao.Domain.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cotacao.Domain.Cotacao
{
    public interface ICotacaoRepository
    {
        Task<IEnumerable<CotacaoModel>> Consultar();
        Task<long> Adicionar(CotacaoModel model);
        Task<bool> Atualizar(CotacaoModel model);
        Task<bool> Remover(CotacaoModel model);
    }
}
