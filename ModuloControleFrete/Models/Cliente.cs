using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloControleFrete.Models
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
        public string Email { get; set; }

        [Required]
        public string Teleone { get; set;  }
        
    }
}
