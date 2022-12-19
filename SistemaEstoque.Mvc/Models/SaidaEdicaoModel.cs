using System.ComponentModel.DataAnnotations;

namespace SistemaEstoque.Mvc.Models
{
    public class SaidaEdicaoModel
    {
        public string? Nome { get; set; }

        public Guid IdSaida { get; set; }

        public Guid IdMercadoria { get; set; }

        [Required(ErrorMessage = "Por favor, informe a quantidade.")]
        public string Quantidade { get; set; }

        public DateTime DataHora { get; set; }

        [Required(ErrorMessage = "Por favor, informe o local.")]
        public string Local { get; set; }
    }
}
