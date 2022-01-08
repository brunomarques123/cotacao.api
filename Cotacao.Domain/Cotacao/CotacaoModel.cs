using System;

namespace Cotacao.Domain.Cotacao
{
    public class CotacaoModel 
    {
        public long? IdCotacao { get; set; }
        public string CNPJComprador { get; set; }
        public string CNPJFornecedor { get; set; }
        public long? NumeroCotacao { get; set; }
        public DateTime? DataCotacao { get; set; }
        public DateTime? DataEntregaCotacao { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string UF { get; set; }
        public string Observacao { get; set; }
    }
}
