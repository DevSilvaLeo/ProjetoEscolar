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
        public const string ControleTotal = "ControleTotal";
        public const string Administrativo = "Administrativo";
        public const string Financeiro = "Financeiro";
        public const string Professor = "Professor";
        public const string Aluno = "Aluno";
        public const string Coordenador = "Coordenador";

        public const string Secretaria = ControleTotal + "," + Administrativo + "," + Coordenador;
        public const string AdministracaoFinanceiro = ControleTotal + "," + Financeiro;
        public const string Educacional = Professor + "," + Aluno + "," + Coordenador + "," + Administrativo;
    }
}
