using SistemaEstoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstoque.Domain.Interfaces.Services
{
    public interface IMercadoriaDomainService
    {
        void CadastrarMercadoria(Mercadoria mercadoria);
        void AtualizarMercadoria(Mercadoria mercadoria);
        void ExcluirMercadoria(Guid idMercadoria);
        List<Mercadoria> ConsultarMercadorias();
        Mercadoria ObterMercadoria(Guid idMercadoria);
        List<Mercadoria> NomeMercadoria(string nomeMercadoria);
    }
}
