using Dapper;
using Cotacao.Domain.Cotacao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cotacao.Infra.Data
{
    public class CotacaoRepository : BaseRepository, ICotacaoRepository
    {
        public CotacaoRepository(string connectionString) : base(connectionString) { }

        public async Task<IEnumerable<CotacaoModel>> Consultar()
        {
            using var conn = Connection;

            return await conn.QueryAsync<CotacaoModel>(
                @"SELECT * FROM TB_COTACAO");
        }

        public async Task<long> Adicionar(CotacaoModel model)
        {
            using var conn = Connection;

            return await conn.ExecuteScalarAsync<long>(
				@"INSERT INTO TB_COTACAO
					(CNPJComprador,
					CNPJFornecedor,
					NumeroCotacao,
					DataCotacao,
					DataEntregaCotacao,
					Cep,
					Logradouro,
					Complemento,
					Bairro,
					UF,
					Observacao)
				OUTPUT INSERTED.IdCotacao
				VALUES
					(@CNPJComprador,
					@CNPJFornecedor,
					@NumeroCotacao,
					@DataCotacao,
					@DataEntregaCotacao,
					@Cep,
					@Logradouro,
					@Complemento,
					@Bairro,
					@UF,
					@Observacao)"
				, new DynamicParameters(model));
        }

		public async Task<bool> Atualizar(CotacaoModel model)
		{
			using var conn = Connection;

			var query = @"UPDATE TB_COTACAO 
							SET
								CNPJComprador=@CNPJComprador,
								CNPJFornecedor=@CNPJFornecedor,
								NumeroCotacao=@NumeroCotacao,
								DataCotacao=@DataCotacao,
								DataEntregaCotacao=@DataEntregaCotacao,
								Cep=@Cep,
								Logradouro=@Logradouro,
								Complemento=@Complemento,
								Bairro=@Bairro,
								UF=@UF,
								Observacao=@Observacao
							WHERE
								IdCotacao=@IdCotacao";

			return await conn.ExecuteAsync(query, new DynamicParameters(model)) > 0;
		}

		public async Task<bool> Remover(CotacaoModel model)
		{
			using var conn = Connection;

			var query = @"DELETE FROM TB_COTACAO 
						  WHERE IdCotacao=@IdCotacao";

			return await conn.ExecuteAsync(query, new DynamicParameters(model)) > 0;
		}
	}
}
