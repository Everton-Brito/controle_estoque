using SistemaEstoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstoque.Domain.Interfaces.Reports
{
    public interface IRelatorioReport
    {
        byte[] CreatePdf(List<Entrada> entradas, List<Saida> saidas);
    }
}
