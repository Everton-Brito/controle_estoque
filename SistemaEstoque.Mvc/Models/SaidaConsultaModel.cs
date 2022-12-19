using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Mvc.Models
{
    public class SaidaConsultaModel
    {
        public Guid IdSaida { get; set; }
        public string Nome { get; set; }
        public string Quantidade { get; set; }
        public DateTime DataHora { get; set; }
        public string Local { get; set; }
    }
}
