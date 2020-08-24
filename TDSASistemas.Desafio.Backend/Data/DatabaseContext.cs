using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDSASistemas.Desafio.Backend.Models;

namespace TDSASistemas.Desafio.Backend.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Medico> Medicos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

    }
}
