using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TDSASistemas.Desafio.Backend.Models;
using TDSASistemas.Desafio.Backend.Repositories.Interfaces;
using TDSASistemas.Desafio.Backend.Services.Interfaces;

namespace TDSASistemas.Desafio.Backend.Controllers
{
    [ApiController]
    [Route("conta")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepositorio;
        private readonly ITokenService _tokenService;

        public UsuarioController(IUsuarioRepository usuarioRepository, ITokenService tokenService)
        {
            _usuarioRepositorio = usuarioRepository;
            _tokenService = tokenService;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<Usuario>> CriarConta([FromBody] Usuario usuario)
        {
            try
            {
                await _usuarioRepositorio.CriarUsuario(usuario);

                return Ok(new { message = "Usuário Criado Com sucesso" });
            }
            catch (Exception)
            {

                return BadRequest(new { Errormessage =  "Erro ao criar usuário" });
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<Usuario>> Entrar([FromBody] Usuario usuario)
        {
            try
            {
                await _usuarioRepositorio.Login(usuario);
                var token = _tokenService.GenerateToken(usuario);
                usuario.Senha = "";
                return Ok(new { usuario, token });


            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
