using Projeto.ControleEscolar.Domain.Interfaces.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Infra.Security.Helpers
{
    public class MD5Cryptograph : IMD5Cryptograph
    {
        public string Encrypt(string value)
        {
            using (var md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(value));

                var result = string.Empty;
                foreach (var item in hash)
                    result += item.ToString("X2"); //X2 -> hexadecimal

                return result;
            }
        }
    }
}
