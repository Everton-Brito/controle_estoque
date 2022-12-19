using System.ComponentModel.DataAnnotations;

namespace SistemaEstoque.Mvc.Models
{
    public class DashboardRelatorioModel
    {
        [Required(ErrorMessage = "Por favor, selecione o formato do relatorio.")]
        public string Formato { get; set; }
    }
}
