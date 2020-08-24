using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDSASistemas.Desafio.Backend.Models;

namespace TDSASistemas.Desafio.Backend.Repositories.Interfaces
{
    public interface IMedicoRepository
    {
        Task<IEnumerable<Medico>> BuscarTodosOsMedicos();

        Task<IEnumerable<Medico>> BuscarEspecialista(string especialidade);

        Task RegistrarMedico(Medico medico);

        Task DeletarMedico(int id);
    }
}
