﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloControleColeta.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        public string RazaoSocial { get; set; }
        [Required]
        public string CPFCNPJ { get; set; }

        public string NomeFantasia { get; set; }

        public string Login { get; set; }

        [JsonIgnore]
        public byte[] PasswordHash { get; set; }

        [JsonIgnore]
        public byte[] PasswordSalt { get; set; }
    }
}
