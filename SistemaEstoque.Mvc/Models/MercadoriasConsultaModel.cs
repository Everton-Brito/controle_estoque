using SistemaEstoque.Mvc.Entities;

namespace SistemaEstoque.Mvc.Models
{
    public class MercadoriasConsultaModel
    {
        public Guid IdMercadoria { get; set; }
        public string Nome { get; set; }
        public string Registro { get; set; }
        public string Fabricante { get; set; }
        public Tipo Tipo { get; set; }
        public string Descricao { get; set; }
    }
}
