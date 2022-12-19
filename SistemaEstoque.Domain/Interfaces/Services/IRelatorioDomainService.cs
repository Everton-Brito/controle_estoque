using SistemaEstoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstoque.Domain.Interfaces.Services
{
    public interface IRelatorioDomainService
    {
        byte[] GerarPdf(List<Entrada> entradas, List<Saida> saidas);
    }
}
