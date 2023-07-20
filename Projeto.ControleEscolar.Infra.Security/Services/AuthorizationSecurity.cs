using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Projeto.ControleEscolar.Domain.Entities;
using Projeto.ControleEscolar.Domain.Interfaces.Security;
using Projeto.ControleEscolar.Infra.Security.Settings;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Infra.Security.Services
{
    public class AuthorizationSecurity : IAuthorizationSecurity
    {
        private readonly TokenSettings _settings;

        public AuthorizationSecurity(IOptions<TokenSettings> settings)
        {
            _settings = settings.Value;
        }

        public string CreateToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim(ClaimTypes.Role, usuario.Permision.ToString())
                }),

                Expires = DateTime.UtcNow.AddDays(_settings.ExpirationInHours),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
