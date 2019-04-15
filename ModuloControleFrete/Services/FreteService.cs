using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Correios;
using ModuloControleFrete.Models;
using static Correios.CalcPrecoPrazoWSSoapClient;

namespace ModuloControleFrete.Services
{
    public class FreteService : IFreteService
    {        

        public async Task<Frete> GetFreteAsyncc(Produto produto)
        {
            CalcPrecoPrazoWSSoapClient correios = new CalcPrecoPrazoWSSoapClient(EndpointConfiguration.CalcPrecoPrazoWSSoap);

            Correios.cResultado resultado = await correios.CalcPrecoPrazoAsync(String.Empty, String.Empty, produto.nCdServico, produto.sCepOrigem, produto.sCepDestino,
                 produto.nVlPeso, produto.nCdFormato, produto.nVlComprimento, produto.nVlAltura, produto.nVlLargura, produto.nVlDiametro,
                 produto.sCdMaoPropria, produto.nVlValorDeclarado, produto.sCdAvisoRecebimento);

            Correios.cServico servico = resultado.Servicos.FirstOrDefault();

            Frete frete = new Frete
            {

            };

            return frete;


        }
    }
}
