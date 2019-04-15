using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloControleColeta.Models
{
    public class Produto
    {
        public string Id { get; set; }
        [Required]
        public string Descricao { get; set; }

        [Required]
        public string Peso { get; set; }

        [Required]
        public decimal valor { get; set; }

        public string nCdEmpresa { get; set; }

        public string sDsSenha { get; set; }
        public string nCdServico { get; set; }
        public string sCepOrigem { get; set; }
        public string sCepDestino { get; set; }
        public string nVlPeso { get; set; }
        public int nCdFormato { get; set; } // 1 caixa
        public decimal nVlComprimento { get; set; }
        public decimal nVlAltura { get; set; }

        public decimal nVlLargura { get; set; }

        public decimal nVlDiametro { get; set; }
        public string sCdMaoPropria { get; set; }
        public decimal nVlValorDeclarado { get; set; }
        public string sCdAvisoRecebimento { get; set; }

       
    }
}
