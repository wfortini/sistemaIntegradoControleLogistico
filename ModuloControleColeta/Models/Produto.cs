﻿using System;
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

    }
}
