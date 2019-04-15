using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
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
            var usuario = _usuarioServicerService.Autenticar(usuarioDTO.Login, usuarioDTO.Password);

            if (usuario == null)
                return BadRequest(new { message = "Login ou passwod incorretos" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                Id = usuario.Id,
                Login = usuario.Login,
                RazaoSocial = usuario.RazaoSocial,
                nomeFantasia = usuario.NomeFantasia,
                Token = tokenString
            });
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