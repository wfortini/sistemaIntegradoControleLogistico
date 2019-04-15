using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloControleFrete.Models
{
    public class Destino
    {
        public string Id { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public int Numero { get; set; }
        public string CEP { get; set; }
        public string NomeDestinatario;
        public string CPFCNPJDestinatatio { get; set; }
    }
}
