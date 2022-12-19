using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstoque.Domain.Entities
{
    public class Entrada 
    {
        public Guid IdEntrada { get; set; }
        public Guid IdMercadoria { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataHora { get; set; }
        public string Local { get; set; }

        public Mercadoria? Mercadoria { get; set; }
    }
}
