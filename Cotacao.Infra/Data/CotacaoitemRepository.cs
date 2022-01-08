using Dapper;
using Cotacao.Domain.CotacaoItem;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cotacao.Infra.Data
{
    public class CotacaoItemRepository : BaseRepository, ICotacaoItemRepository
    {
        public CotacaoItemRepository(string connectionString) : base(connectionString) { }

        public async Task<IEnumerable<CotacaoItemModel>> Consultar(CotacaoItemModel model)
        {
            using var conn = Connection;

            return await conn.QueryAsync<CotacaoItemModel>(
                @"SELECT * FROM TB_COTACAO_ITEM
	                WHERE IdCotacao = @IdCotacao", new DynamicParameters(model));
        }

		public async Task<long> Adicionar(CotacaoItemModel model)
		{
			using var conn = Connection;

			return await conn.ExecuteScalarAsync<long>(
				@"INSERT INTO TB_COTACAO_ITEM
					(IdCotacao,
					Descricao,
					NumeroItem,
					Preco,
					Quantidade,
					Marca,
					Unidade)
				OUTPUT INSERTED.IdCotacaoItem
				VALUES
					(@IdCotacao,
					@Descricao,
					@NumeroItem,
					@Preco,
					@Quantidade,
					@Marca,
					@Unidade)"
				, new DynamicParameters(model));
		}

		public async Task<bool> Atualizar(CotacaoItemModel model)
		{
			using var conn = Connection;

			var query = @"UPDATE TB_COTACAO_ITEM 
							SET
								Descricao=@Descricao,
								NumeroItem=@NumeroItem,
								Preco=@Preco,
								Quantidade=@Quantidade,
								Marca=@Marca,
								Unidade=@Unidade
							WHERE
								IdCotacaoItem=@IdCotacaoItem";

			return await conn.ExecuteAsync(query, new DynamicParameters(model)) > 0;
		}

		public async Task<bool> Remover(CotacaoItemModel model)
		{
			using var conn = Connection;

			var query = @"DELETE FROM TB_COTACAO_ITEM 
						  WHERE IdCotacaoItem=@IdCotacaoItem";

			return await conn.ExecuteAsync(query, new DynamicParameters(model)) > 0;
		}
	}
}
