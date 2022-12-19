using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Reports;
using SistemaEstoque.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstoque.Domain.Reports
{
    public class ReportService : IRelatorioDomainService
    {
        private readonly IRelatorioReport _relatorioReport;

        public ReportService(IRelatorioReport relatorioReport)
        {
            _relatorioReport = relatorioReport;
        }

        public byte[] GerarPdf(List<Entrada> entradas, List<Saida> saidas)
        {
            if (entradas == null || saidas == null)
            {
                throw new Exception("Não há dados para geração do relatório pdf.");
            }

            return _relatorioReport.CreatePdf(entradas, saidas);
        }
    }
}
