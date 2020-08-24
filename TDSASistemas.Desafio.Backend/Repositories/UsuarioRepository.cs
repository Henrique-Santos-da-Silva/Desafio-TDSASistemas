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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DatabaseContext _context;

        public UsuarioRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task CriarUsuario(Usuario usuario)
        {
            if (_context.Usuarios.Any(u => u.Nome.Equals(usuario.Nome)))
                throw new ArgumentNullException("Usuário com nome inválido ou já existe");

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task Login(Usuario usuario)
        {
            usuario = await _context.Usuarios.Where(u => u.Nome == usuario.Nome
                && u.Senha == usuario.Senha).FirstOrDefaultAsync();

            if (usuario == null) throw new ArgumentNullException();
        }
    }
}
