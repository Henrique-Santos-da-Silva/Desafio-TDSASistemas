using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TDSASistemas.Desafio.Backend.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é Obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Senha é Obrigatório")]
        public string Senha { get; set; }
    }
}
