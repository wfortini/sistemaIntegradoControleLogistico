using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloControleFrete.Models
{
    public class Frete
    {
        public string Id { get; set; }
        public decimal valor { get; set; }
        public int prazoEntregaDias { get; set; }
        public DateTime dataPrevista { get; set; }

        public string codeErro { get; set; }
        public string msgErro { get; set; }
    }
}
