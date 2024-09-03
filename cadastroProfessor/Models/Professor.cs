using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastroProfessor.Models
{
    internal class Professor
    {
        public int idProfessor { get; set; }
        public string nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string telefone { get; set; }
        public DateOnly dataNascimento { get; set; }
        public string sexo { get; set; }
        public string formacao { get; set; }
    }
}
