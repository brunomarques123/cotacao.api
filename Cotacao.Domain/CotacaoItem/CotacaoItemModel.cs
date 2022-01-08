namespace Cotacao.Domain.CotacaoItem
{
    public class CotacaoItemModel
    {
        public long? IdCotacaoItem { get; set; }
        public long? IdCotacao { get; set; } // 1 2 3 4
        public string Descricao { get; set; }
        public long? NumeroItem { get; set; }
        public string Marca { get; set; }
        public string Unidade { get; set; }
        public decimal? Preco { get; set; }
        public decimal? Quantidade { get; set; }
    }
}
