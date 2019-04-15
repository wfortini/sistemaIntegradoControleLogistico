using ModuloControleColeta.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloControleFrete.Models
{
    public class Solicitacao
    {

        public string Id { get; set; }
        public string Observacao { get; set; }
        public DateTime dataSolicitacao { get; set; }

        [Required]
        public Produto Produto { get; set;  }
        public Destino Destino { get; set; }
        public int Status { get; set; }
        public DateTime dataPrevistaEntrega { get; set; }

        [Required]
        public Cliente ClienteSolicitante { get; set; }
        public Frete Frete { get; set; }

        public Usuario Parceiro { get; set; }

    }
}
