using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Correios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModuloControleFrete.Models;
using ModuloControleFrete.Services;
using static Correios.CalcPrecoPrazoWSSoapClient;

namespace ModuloControleFrete.Controller
{

    

    [Route("api/[controller]")]
    [ApiController]
    public class FreteController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<Frete>> SimulaFreteAsync()
        {
            Produto produto = new Produto
            {
                nCdEmpresa = String.Empty,
                nCdFormato = 1,
                nCdServico = "1",
                Descricao = "teste",
                nVlAltura = new decimal(1.60),
                nVlComprimento = new decimal(2.00),
                nVlDiametro = new decimal(3.00),
                nVlPeso = "20",
                nVlLargura = new decimal(0.50),
                nVlValorDeclarado = new decimal(2.000),
                sCdAvisoRecebimento = "N",
                sCdMaoPropria = "N",
                sCepDestino = "20261050",
                sCepOrigem = "04180112",
                sDsSenha = String.Empty



            };

            IFreteService service = new FreteService();

            Frete frete = await service.GetFreteAsyncc(produto);
            


            return frete;
        }
    }
}