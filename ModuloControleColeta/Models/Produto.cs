using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloControleColeta.Models
{
    public class Produto
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public string Peso { get; set; }
        public decimal valor { get; set; }

    }
}
