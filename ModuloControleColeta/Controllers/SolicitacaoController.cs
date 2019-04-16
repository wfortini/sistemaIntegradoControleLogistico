using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModuleControleColeta.Models;
using ModuloControleColeta.Models;
using ModuloControleColeta.Services;
using ModuloControleFrete.Services;

namespace ModuleControleColeta.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitacaoController : Controller
    {
        private readonly ISolicitacaoService _service;
        private readonly IUsuarioService _usuarioService;
        private readonly IFreteService _freteService;

        public SolicitacaoController(ISolicitacaoService service, IUsuarioService usuario, IFreteService sfrete)
        {
            _service = service;
            _usuarioService = usuario;
            _freteService = sfrete;
        }    

        // GET: api/solicitacao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModuloControleFrete.Models.Frete>> getSolicitacaoPorId(string id)
        {
            var produto = new ModuloControleFrete.Models.Produto
            {
                nCdEmpresa = String.Empty,
                nCdFormato = 1,
                nCdServico = "41106",
                Descricao = "teste",
                nVlAltura = new decimal(20.60),
                nVlComprimento = new decimal(35.00),
                nVlDiametro = new decimal(50.00),
                nVlPeso = "20",
                nVlLargura = new decimal(40.00),
                nVlValorDeclarado = new decimal(2000),
                sCdAvisoRecebimento = "N",
                sCdMaoPropria = "N",
                sCepDestino = "20261050",
                sCepOrigem = "04180112",
                sDsSenha = String.Empty



            };

            ModuloControleFrete.Models.Frete frete = await _freteService.GetFreteAsyncc(produto);
            

            //var solic =  _service.BuscarSolicitacaoPorId(id);

           // if(solic == null)
            ////{
            //    return NotFound();
           // }

            return frete;
        }

        [HttpPost]
        public async Task<ActionResult<Solicitacao>> CriarSolicitacao(Solicitacao solicitacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string userId = HttpContext.User.Identity.Name;

            Usuario parceiro = _usuarioService.GetById(int.Parse(userId));

            if(parceiro == null)
            {
                return BadRequest("Perceiro não encontrado.");
            }

            solicitacao.Parceiro = parceiro;

            Solicitacao newSolicitacao = _service.CriarSolicitacao(solicitacao);

            newSolicitacao.Parceiro.PasswordHash = null;
            newSolicitacao.Parceiro.PasswordSalt = null;

            return CreatedAtAction(nameof(getSolicitacaoPorId), new { id = newSolicitacao.Id }, newSolicitacao);
        }

        public async Task<ActionResult<Solicitacao>> AtualizarSolicitacao(string id, Solicitacao solicitacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id == null)
            {
                return NotFound();
            }

            if(id != solicitacao.Id)
            {
                return BadRequest();
            }

            _service.AtualizarSolicitacao(solicitacao);

            return NoContent();
        }
    }
}