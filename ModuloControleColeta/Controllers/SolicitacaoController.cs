using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public SolicitacaoController(ISolicitacaoService service, IUsuarioService usuario, IFreteService sfrete, IMapper mapper)
        {
            _service = service;
            _usuarioService = usuario;
            _freteService = sfrete;
            _mapper = mapper;
        }


        [AllowAnonymous]
        [HttpPost("simularFrete")]
        public async Task<ActionResult<ModuloControleFrete.Models.Frete>> SimularFrete(ModuloControleFrete.Models.Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await this.getFrete(produto);

           
        }

        // GET: api/solicitacao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Solicitacao>> getSolicitacaoPorId(string id)
        {
            

           var solic =  _service.BuscarSolicitacaoPorId(id);

            if(solic == null)
           {
           }

            return solic;
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

            ModuloControleFrete.Models.Produto produto = _mapper.Map<ModuloControleFrete.Models.Produto>(solicitacao.Produto);
            ModuloControleFrete.Models.Frete frete = await this.getFrete(produto);

            solicitacao.Frete.dataPrevista = frete.dataPrevista;
            solicitacao.Frete.prazoEntregaDias = frete.prazoEntregaDias;
            solicitacao.Frete.valor = frete.valor;

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

        private async Task<ModuloControleFrete.Models.Frete> getFrete(ModuloControleFrete.Models.Produto produto)
        {

            produto.nCdEmpresa = String.Empty;
            produto.sCdAvisoRecebimento = "N";
            produto.sDsSenha = String.Empty;
            produto.nCdFormato = 1; // caixa
            produto.nCdServico = "41106";

            ModuloControleFrete.Models.Frete frete = await _freteService.GetFreteAsyncc(produto);

            if (String.IsNullOrEmpty(frete.codeErro))
            {
                frete.dataPrevista = DateTime.Now;
                frete.dataPrevista = frete.dataPrevista.AddDays(frete.prazoEntregaDias);
                frete.codeErro = String.Empty;
                frete.msgErro = String.Empty;
                frete.Id = Guid.NewGuid().ToString();
                return frete;
            }
            else
            {


                return frete;
            }

        }
    }
}