using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ModuloControleColeta.Models;
using ModuloControleColeta.Services;

namespace ModuloControleColeta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private IUsuarioService _usuarioServicerService;
        private readonly AppSettings _appSettings;

        public UsuarioController(IUsuarioService usuarioServicerService, IOptions<AppSettings> appSettings)
        {
            _usuarioServicerService = usuarioServicerService;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("autenticar")]
        public IActionResult Autenticar([FromBody]UsuarioDTO usuarioDTO)
        {

            return null;
        }

        [AllowAnonymous]
        [HttpPost("registrar")]
        public IActionResult Registrar([FromBody]UsuarioDTO usuarioDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Usuario usuario = new Usuario
            {
                CPFCNPJ = usuarioDTO.CPFCNPJ,
                Login = usuarioDTO.Login,
                NomeFantasia = usuarioDTO.NomeFantasia,
                RazaoSocial = usuarioDTO.RazaoSocial,

            };

            try
            {

                _usuarioServicerService.Registrar(usuario, usuarioDTO.Password);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }
    }
}