using SistemaEstoque.Mvc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstoque.Domain.Entities
{
    public class Mercadoria
    {
        public Guid IdMercadoria { get; set; }        
        public string Nome { get; set; }
        public string Registro { get; set; }
        public string Fabricante { get; set; }
        public Tipo Tipo { get; set; }
        public string Descricao { get; set; }

        public List<Entrada>? Entradas { get; set; }
        public List<Saida>? Saidas { get; set; }
    }
}
