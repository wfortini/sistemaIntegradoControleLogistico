using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Correios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Correios.CalcPrecoPrazoWSSoapClient;

namespace ModuloControleFrete.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FreteController : ControllerBase
    {
        public IActionResult post()
        {

            CalcPrecoPrazoWSSoapClient correios = new CalcPrecoPrazoWSSoapClient(EndpointConfiguration.CalcPrecoPrazoWSSoap);

            correios.CalcPrecoPrazoAsync()

            return null;
        }
    }
}