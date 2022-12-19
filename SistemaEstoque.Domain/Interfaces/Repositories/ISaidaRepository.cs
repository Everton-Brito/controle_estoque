using SistemaEstoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstoque.Domain.Interfaces.Repositories
{
    public interface ISaidaRepository
    {
        void Create(Saida saida);
        void Update(Saida saida);
        void Delete(Saida saida);
        List<Saida> GetAll();
        Saida GetById(Guid idSaida);
        Saida GetByNome(string nome);

    }
}
