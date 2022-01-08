using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotacao.Domain.Shared
{
    public interface IBaseRepository<Model>
    {
        Task<IEnumerable<Model>> ConsultarTodos();
        Task<Model> ConsultarPorId(long id);
        Task<long> Adicionar(Model modelo);
        Task<bool> Atualizar(Model modelo);
    }
}
