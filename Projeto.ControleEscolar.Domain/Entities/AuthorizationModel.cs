using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Domain.Entities
{
    public class AuthorizationModel
    {
        public string? AccessToken { get; set; }
        public DateTime DataHoraAcesso { get; set; }
    }
}
