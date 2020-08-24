using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDSASistemas.Desafio.Backend.Data;
using TDSASistemas.Desafio.Backend.Models;
using TDSASistemas.Desafio.Backend.Repositories.Interfaces;

namespace TDSASistemas.Desafio.Backend.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {

        private readonly DatabaseContext _context;

        public MedicoRepository(DatabaseContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Medico>> BuscarEspecialista(string especialidade)
        {
            var medicos = from m in _context.Medicos
                          select m;

            if (!String.IsNullOrEmpty(especialidade))
            {
                medicos = medicos.Where(e => e.Especialidades.ToLower().Contains(especialidade.ToLower()));

            }

            return await medicos.ToListAsync();
        }

        public async Task<IEnumerable<Medico>> BuscarTodosOsMedicos() =>
            await _context.Medicos.ToListAsync();

        public async Task DeletarMedico(int id)
        {
            var medico = _context.Medicos.Find(id);

            if (medico == null) throw new ArgumentNullException("O Médico com o id buscado não existe");

            _context.Medicos.Remove(medico);
            await _context.SaveChangesAsync();
        }

        public async Task RegistrarMedico(Medico medico)
        {
            if (medico == null || _context.Medicos.Any(m => m.Crm.Equals(medico.Crm)))
                throw new ArgumentNullException("Os dados do médico está nulo ou este médico já existe");

            if (medico.Cpf.Length == 14 || medico.Cpf.Length == 11)
            {
                _context.Add(medico);
                await _context.SaveChangesAsync();

            } else
            {
                throw new Exception("CPF inválido");
            }

        }
    }
}
