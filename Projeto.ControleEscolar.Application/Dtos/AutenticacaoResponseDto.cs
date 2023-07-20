using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Application.Dtos
{
    public class AutenticacaoResponseDto
    {
        public string AccessToken { get; set; }
        public DateTime DataHoraAcesso { get; set; }
    }
}
