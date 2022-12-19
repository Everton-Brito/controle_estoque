using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Mvc.Models
{
    public class EntradaConsultaModel
    {
        public Guid IdEntrada { get; set; }
        public string Nome { get; set; }  
        public int Quantidade { get; set; }
        public DateTime DataHora { get; set; }       
        public string Local { get; set; }
        
    }
}
