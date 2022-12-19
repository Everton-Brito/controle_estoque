using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaEstoque.Mvc.Entities;
using System.ComponentModel.DataAnnotations;

namespace SistemaEstoque.Mvc.Models
{
    public class MercadoriaEdicaoModel
    {
        public Guid IdMercadoria { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome da mercadoria.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o número do registro da mercadoria.")]
        public string Registro { get; set; }

        [Required(ErrorMessage = "Por favor, informe o fabricante da mercadoria.")]
        public string Fabricante { get; set; }

        [Required(ErrorMessage = "Por favor, informe o tipo da mercadoria.")]
        public Tipo Tipo { get; set; }

        [Required(ErrorMessage = "Por favor, informe a descrição da mercadoria.")]
        public string Descricao { get; set; }

    }
}
