using Projeto.ControleEscolar.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Application.Interfaces
{
    public interface IAutenticacaoApplicationService
    {
        AutenticacaoResponseDto Login(AutenticacaoRequestDto request);
        void ForgotPassword(string email);
    }
}
