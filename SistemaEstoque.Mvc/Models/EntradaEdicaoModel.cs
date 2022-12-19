using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace SistemaEstoque.Mvc.Models
{
    public class EntradaEdicaoModel
    {
        public Guid IdEntrada { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a quantidade.")]
        public string Quantidade { get; set; }

        public DateTime DataHora { get; set; }

        [Required(ErrorMessage = "Por favor, informe o local.")]
        public string Local { get; set; }

        public List<SelectListItem>? Mercadorias { get; set; }

    }
}
