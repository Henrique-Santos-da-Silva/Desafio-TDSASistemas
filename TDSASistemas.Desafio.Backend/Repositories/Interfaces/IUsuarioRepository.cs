using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDSASistemas.Desafio.Backend.Models;

namespace TDSASistemas.Desafio.Backend.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task CriarUsuario(Usuario usuario);

        Task Login(Usuario usuario);


    }
}
