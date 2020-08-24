using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TDSASistemas.Desafio.Backend.Models
{
    public class Medico
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [MaxLength(255, ErrorMessage = "Nome deve conter no máximo 255 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "CRM é obrigatório")]
        public string Crm { get; set; }

        [Required(ErrorMessage = "É preciso ter ao menos uma especialidade")]
        public string Especialidades { get; set; }
    }
}
