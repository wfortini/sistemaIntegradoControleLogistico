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

        
        public string Peso { get; set; }

        [Required]
        public decimal valor { get; set; }

        [Required]
        public string Nome { get; set; }

        
        public string nCdEmpresa { get; set; }

        public string sDsSenha { get; set; }
        public string nCdServico { get; set; }

        [Required]
        public string sCepOrigem { get; set; }

        [Required]
        public string sCepDestino { get; set; }

        [Required]
        public string nVlPeso { get; set; }
        public int nCdFormato { get; set; } // 1 caixa

        [Required]
        public decimal nVlComprimento { get; set; }

        [Required]
        public decimal nVlAltura { get; set; }

        public decimal nVlLargura { get; set; }

        [Required]
        public decimal nVlDiametro { get; set; }

        public string sCdMaoPropria { get; set; }

        [Required]
        public decimal nVlValorDeclarado { get; set; }

        [Required]
        public string sCdAvisoRecebimento { get; set; }


    }
}
