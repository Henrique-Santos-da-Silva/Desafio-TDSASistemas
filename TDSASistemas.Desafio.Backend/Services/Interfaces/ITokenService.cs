using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDSASistemas.Desafio.Backend.Models;

namespace TDSASistemas.Desafio.Backend.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(Usuario usuario);
    }
}
