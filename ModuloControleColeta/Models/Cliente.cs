using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloControleColeta.Models
{
    public class Cliente
    {
        public string Id { get; set; }

        [Required]
        public string RazaoSocial { get; set; }

        [Required]
        public string CNPJ { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        public string teleone { get; set;  }
        
    }
}
