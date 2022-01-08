using Cotacao.Domain.Cotacao;
using Cotacao.Domain.Shared;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cotacao.Service
{
    public class CotacaoService : ICotacaoService
    {
        private readonly ConfigurationViewModel _configuration;
        private readonly ICotacaoRepository _cotacaoRepository;

        public CotacaoService(IConfiguration configuration, ICotacaoRepository cotacaoRepository)
        {
            _configuration = new ConfigurationViewModel(configuration);
            _cotacaoRepository = cotacaoRepository;
        }

        public async Task<IEnumerable<CotacaoModel>> ConsultarCotacao()
        {
            return await _cotacaoRepository.Consultar();
        }

        public async Task<long> InserirCotacao(CotacaoModel viewModel)
        {
            if (!ValidaCamposObrigatorios(viewModel))
                return 0;

            try
            {
                var resultado = await FuncoesWeb.GetEnderecoWeb(viewModel.Cep); // consulta pelo cep

                viewModel.Logradouro = resultado.logradouro;
                viewModel.Bairro = resultado.bairro;
                viewModel.UF = resultado.uf;
            }
            catch
            {
                throw new Exception("Endereço não pode ser localizado.");
            }


            return await _cotacaoRepository.Adicionar(viewModel);
        }

        public async Task<bool> AlterarCotacao(CotacaoModel viewModel)
        {
            if (!ValidaCamposObrigatorios(viewModel))
                return false;

            if (viewModel.IdCotacao <= 0 || viewModel.IdCotacao == null)
                throw new Exception("Id da Cotação é campo obrigatório.");

            return await _cotacaoRepository.Atualizar(viewModel);
        }

        public async Task<bool> ExcluirCotacao(CotacaoModel viewModel)
        {
            if (viewModel.IdCotacao <= 0 || viewModel.IdCotacao == null)
                throw new Exception("Id da Cotação é campo obrigatório.");

            return await _cotacaoRepository.Remover(viewModel);
        }

        private bool ValidaCamposObrigatorios(CotacaoModel viewModel)
        {
            if (string.IsNullOrEmpty(viewModel.CNPJComprador))
                throw new Exception("CNPJ Comprador é campo obrigatório.");

            if (string.IsNullOrEmpty(viewModel.CNPJFornecedor))
                throw new Exception("CNPJ Fornecedor é campo obrigatório.");

            if (viewModel.NumeroCotacao == 0 || viewModel.NumeroCotacao == null)
                throw new Exception("Número da Cotação é campo obrigatório.");

            if (viewModel.DataCotacao == null)
                throw new Exception("Data Cotação é campo obrigatório.");

            if (viewModel.DataEntregaCotacao == null)
                throw new Exception("Data Entraga Cotação é campo obrigatório.");

            if (string.IsNullOrEmpty(viewModel.Cep))
                throw new Exception("Cep é campo obrigatório.");

            return true;
        }
    }
}
