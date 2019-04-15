using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModuleControleColeta.Models;
using ModuloControleColeta.Models;
using ModuloControleColeta.Services;

namespace ModuleControleColeta.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitacaoController : Controller
    {
        private readonly ISolicitacaoService _service;
        private readonly IUsuarioService _usuarioService;

        public SolicitacaoController(ISolicitacaoService service, IUsuarioService usuario)
        {
            _service = service;
            _usuarioService = usuario;
        }    

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Solicitacao>> getSolicitacaoPorId(string id)
        {
            

            var solic =  _service.BuscarSolicitacaoPorId(id);

            if(solic == null)
            {
                return NotFound();
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