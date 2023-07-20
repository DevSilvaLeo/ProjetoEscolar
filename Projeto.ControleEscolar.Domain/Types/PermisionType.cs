using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Domain.Types
{
    public enum PermisionType
    {
        ControleTotal = 1,
        Administrativo = 2,
        Administrador = 3,
        Professor = 4,
        Aluno = 5,
        Coordenador = 6
    }

    public static class ControleEscolarPermisionRoles
    {
        public const string ControleTotal = "1";
        public const string Administrativo = "2";
        public const string Financeiro = "3";
        public const string Professor = "4";
        public const string Aluno = "5";
        public const string Coordenador = "6";

        public const string Secretaria = ControleTotal + "," + Administrativo + "," + Coordenador;
        public const string AdministracaoFinanceiro = ControleTotal + "," + Financeiro;
        public const string Educacional = Professor + "," + Aluno + "," + Coordenador + "," + Administrativo;
    }
}
