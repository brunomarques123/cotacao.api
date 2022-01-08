using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cotacao.Domain.CotacaoItem
{
    public interface ICotacaoItemService
    {
        Task<IEnumerable<CotacaoItemModel>> ConsultarItemCotacao(CotacaoItemModel model);
        Task<long> InserirItemCotacao(CotacaoItemModel viewModel);
        Task<bool> AlterarItemCotacao(CotacaoItemModel viewModel);
        Task<bool> ExcluirItemCotacao(CotacaoItemModel viewModel);
    }
}
