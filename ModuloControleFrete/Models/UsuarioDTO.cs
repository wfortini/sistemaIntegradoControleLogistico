using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloControleFrete.Models
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string CPFCNPJ { get; set; }
        public string NomeFantasia { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
