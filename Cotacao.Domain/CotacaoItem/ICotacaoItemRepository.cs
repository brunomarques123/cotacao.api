using Cotacao.Domain.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cotacao.Domain.CotacaoItem
{
    public interface ICotacaoItemRepository
    {
        Task<IEnumerable<CotacaoItemModel>> Consultar(CotacaoItemModel model);
        Task<long> Adicionar(CotacaoItemModel model);
        Task<bool> Atualizar(CotacaoItemModel modelo);
        Task<bool> Remover(CotacaoItemModel modelo);
    }
}
