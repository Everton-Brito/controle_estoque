using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace SistemaEstoque.Mvc.Models
{
    public class EntradaEdicaoModel
    {
        public Guid IdEntrada { get; set; }

        public Guid IdMercadoria { get; set; }


        [Required(ErrorMessage = "Por favor, informe a quantidade.")]
        public string Quantidade { get; set; }

        public DateTime DataHora { get; set; }

        [Required(ErrorMessage = "Por favor, informe o local.")]
        public string Local { get; set; }


    }
}
