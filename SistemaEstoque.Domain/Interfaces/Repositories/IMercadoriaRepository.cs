using SistemaEstoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstoque.Domain.Interfaces.Repositories
{
    public interface IMercadoriaRepository
    {
        void Create(Mercadoria mercadoria);
        void Update(Mercadoria mercadoria);
        void Delete(Mercadoria mercadoria);
        List<Mercadoria> GetAll();
        Mercadoria GetById(Guid idMercadoria);
        List<Mercadoria> GetMercadorias(string nomeMercadoria);
    }
}
