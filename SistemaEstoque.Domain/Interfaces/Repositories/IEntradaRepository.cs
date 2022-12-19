using SistemaEstoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstoque.Domain.Interfaces.Repositories
{
    public interface IEntradaRepository
    {
        void Create(Entrada entrada);
        void Update(Entrada entrada);
        void Delete(Entrada entrada);
        List<Entrada> GetAll();
        Entrada GetById(Guid idEntrada);
        Entrada GetByNome(string nome);
        
    }
}
