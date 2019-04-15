using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Correios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModuloControleFrete.Services;
using static Correios.CalcPrecoPrazoWSSoapClient;

namespace ModuloControleFrete.Controller
{

    

    [Route("api/[controller]")]
    [ApiController]
    public class FreteController : ControllerBase
    {
        public IActionResult post()
        {

            IFreteService service = new FreteService();
            


            return null;
        }
    }
}