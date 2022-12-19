using SistemaEstoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstoque.Domain.Interfaces.Services
{
    public interface IEntradaDomainService
    {
        void CadastrarEntrada(Entrada entrada);
        void AtualizarEntrada(Entrada entrada);
        void ExcluirEntrada(Guid idEntrada);
        List<Entrada> ConsultarEntradas();
        Entrada ObterEntrada(Guid idEntrada);
        Entrada ObterNome(string nome);
    }
}
