using SistemaEstoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstoque.Domain.Interfaces.Services
{
    public interface ISaidaDomainService
    {
        void CadastrarSaida(Saida saida);
        void AtualizarSaida(Saida saida);
        void ExcluirSaida(Guid id);
        List<Saida> ConsultarSaidas();
        Saida ObterSaida(Guid idsaida);
        Saida ObterNome(string nome);
    }
}
