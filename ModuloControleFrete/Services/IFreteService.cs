﻿using ModuloControleFrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloControleFrete.Services
{
    public interface IFreteService
    {
       Task<Frete> GetFreteAsyncc(Produto produto);
    }
}
