using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Domain.Interfaces.Security
{
    public interface IMD5Cryptograph
    {
        string Encrypt(string value);
    }
}
