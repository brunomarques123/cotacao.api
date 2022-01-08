using System;

namespace Cotacao.Domain.Shared
{
    public abstract class BaseModel
    {
        public BaseModel()
        {
            DataHoraCadastro = DateTime.Now;
            Ativo = true;
        }
        public long Id { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public bool Ativo { get; set; }
    }
}
