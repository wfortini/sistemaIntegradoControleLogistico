﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloControleFrete.Services
{
    public interface IFreteService
    {
        public async Task<Frete> GetFreteAsync()
    }
}
