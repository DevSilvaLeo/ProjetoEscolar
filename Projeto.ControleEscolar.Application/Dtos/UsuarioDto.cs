using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Application.Dtos
{
    public record UsuarioInputDto(string Email, string Password, int Permision, string Status);
    public record UsuarioOutputDto(int Id, string Email, string Password, int Permision, string Status);
}
