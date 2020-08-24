using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TDSASistemas.Desafio.Backend.Models;
using TDSASistemas.Desafio.Backend.Repositories.Interfaces;

namespace TDSASistemas.Desafio.Backend.Controllers
{
    [ApiController]
    [Route("")]
    [Route("[controller]")]
    public class MedicosController : Controller
    {
        private IMedicoRepository _medicoRepository;

        public MedicosController(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medico>>> BuscarTodosOsMedicos()
        {
            var medicos = await _medicoRepository.BuscarTodosOsMedicos();
            return Ok(medicos);
        }

        [HttpGet("{especialidade}")]
        public async Task<ActionResult<Medico>> BuscarPorEspecialista(string especialidade)
        {
            var medicoEspecialista = await _medicoRepository.BuscarEspecialista(especialidade);

            if (medicoEspecialista == null) return NotFound(medicoEspecialista);

            return Ok(medicoEspecialista);
        }

        [HttpPost]
        public async Task<ActionResult<Medico>> RegistrarMedico([FromBody] Medico medico)
        {
            try
            {
                await _medicoRepository.RegistrarMedico(medico);

                return CreatedAtAction(nameof(BuscarTodosOsMedicos), new { id = medico.Id }, medico);
            }
            catch (Exception)
            {

                return BadRequest(medico);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarMedico(int id)
        {
            try
            {
                await _medicoRepository.DeletarMedico(id);
                return Ok();
            }
            catch (Exception)
            {

                return NotFound();
            }
        }
    }
}
