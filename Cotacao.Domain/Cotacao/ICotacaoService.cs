using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cotacao.Domain.Cotacao
{
    public interface ICotacaoService
    {
        Task<IEnumerable<CotacaoModel>> ConsultarCotacao();
        Task<long> InserirCotacao(CotacaoModel viewModel);
        Task<bool> AlterarCotacao(CotacaoModel viewModel);
        Task<bool> ExcluirCotacao(CotacaoModel viewModel);
    }
}
