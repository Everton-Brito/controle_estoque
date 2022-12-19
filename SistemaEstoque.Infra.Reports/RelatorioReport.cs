using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstoque.Infra.Reports
{
    public class RelatorioReport : IRelatorioReport
    {
        public byte[] CreatePdf(List<Entrada> entradas, List<Saida> saidas)
        {
            var memoryStream = new MemoryStream();
            var pdf = new PdfDocument(new PdfWriter(memoryStream));

            using (var document = new Document(pdf))
            {
                document.Add(new Paragraph("Relatório de Entradas e Saidas\n"));

                document.Add(new Paragraph($"Data de geração: {DateTime.Now.ToString()}"));

                var table = new Table(4);
                table.SetWidth(UnitValue.CreatePercentValue(100));

                table.AddHeaderCell("Entrada/Saida");
                table.AddHeaderCell("Quantidade");
                table.AddHeaderCell("Data e Hora");
                table.AddHeaderCell("Local");

                foreach (var item in entradas)
                {
                    table.AddCell("Entrada");
                    table.AddCell(item.Quantidade.ToString());
                    table.AddCell(item.DataHora.ToString());
                    table.AddCell(item.Local);
                }

                foreach (var item in saidas)
                {
                    table.AddCell("Saida");
                    table.AddCell(item.Quantidade.ToString());
                    table.AddCell(item.DataHora.ToString());
                    table.AddCell(item.Local);
                }

                document.Add(table);
            }

            return memoryStream.ToArray();
        }
    }
}
