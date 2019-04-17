using Newtonsoft.Json;
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
        public decimal valor { get; set; }

        [Required]
        public string Nome { get; set; }

        [JsonIgnore]
        public string nCdEmpresa { get; set; }

        [JsonIgnore]
        public string sDsSenha { get; set; }
        [JsonIgnore]
        public string nCdServico { get; set; }

        [Required]
        public string sCepOrigem { get; set; }

        [Required]
        public string sCepDestino { get; set; }

        [Required]
        public string nVlPeso { get; set; }

        [JsonIgnore]
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
