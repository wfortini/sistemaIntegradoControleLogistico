using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModuleControleColeta.Models;
using ModuloControleColeta.Services;

namespace ModuleControleColeta.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitacaoController : Controller
    {
        private readonly ISolicitacaoService _service;

        public SolicitacaoController(ISolicitacaoService service)
        {
            _service = service;
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

            Solicitacao newSolicitacao = _service.CriarSolicitacao(solicitacao);

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