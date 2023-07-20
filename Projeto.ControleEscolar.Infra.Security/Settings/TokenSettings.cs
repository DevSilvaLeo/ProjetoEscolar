using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Infra.Security.Settings
{
    public class TokenSettings
    {
        public string? SecretKey { get; set; }
        public int ExpirationInHours { get; set; }
    }
}
