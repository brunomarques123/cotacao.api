using Cotacao.Domain.CotacaoItem;
using Cotacao.Domain.Shared;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cotacao.Service
{
    public class CotacaoItemService : BaseService, ICotacaoItemService
    {
        private readonly ICotacaoItemRepository _cotacaoItemRepository;
        public CotacaoItemService(IConfiguration configuration, INotificador notificador, ICotacaoItemRepository cotacaoItemRepository) 
            : base(configuration, notificador)
        {
            _cotacaoItemRepository = cotacaoItemRepository;
        }

        public async Task<IEnumerable<CotacaoItemModel>> ConsultarItemCotacao(CotacaoItemModel model)
        {
            return await _cotacaoItemRepository.Consultar(model);
        }

        public async Task<long> InserirItemCotacao(CotacaoItemModel viewModel)
        {
            if (!ValidaCamposObrigatorios(viewModel))
                return 0;

            return await _cotacaoItemRepository.Adicionar(viewModel);
        }

        public async Task<bool> AlterarItemCotacao(CotacaoItemModel viewModel)
        {
            if (!ValidaCamposObrigatorios(viewModel))
                return false;

            if (viewModel.IdCotacaoItem <= 0 || viewModel.IdCotacaoItem == null)
                throw new Exception("Id é campo obrigatório.");

            return await _cotacaoItemRepository.Atualizar(viewModel);
        }

        public async Task<bool> ExcluirItemCotacao(CotacaoItemModel viewModel)
        {
            if (viewModel.IdCotacaoItem <= 0 || viewModel.IdCotacaoItem == null)
                throw new Exception("Id é campo obrigatório.");

            return await _cotacaoItemRepository.Remover(viewModel);
        }

        private bool ValidaCamposObrigatorios(CotacaoItemModel viewModel)
        {
            if (string.IsNullOrEmpty(viewModel.Descricao))
                throw new Exception("Descrição do Item é campo obrigatório.");

            if (viewModel.NumeroItem == 0 || viewModel.NumeroItem == null)
                throw new Exception("Número do Item é campo obrigatório.");

            if (viewModel.Quantidade == 0 || viewModel.Quantidade == null)
                throw new Exception("Quantidade do Item é campo obrigatório.");

            return true;
        }
    }
}
