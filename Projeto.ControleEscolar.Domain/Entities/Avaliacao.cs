using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Domain.Entities
{
    public class Avaliacao
    {
        public int Id { get; set; }
        public decimal N1 { get; set; }
        public decimal N2 { get; set; }
        public decimal N3 { get; set; }
        public decimal Media { get; set; }
        public Aluno? Aluno { get; set; }
        public Disciplina? Disciplina { get; set; }
    }
}
