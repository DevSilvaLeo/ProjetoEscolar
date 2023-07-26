using Projeto.ControleEscolar.Domain.Entities;
using Projeto.ControleEscolar.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Application.Dtos
{
    public record MensalidadeInputDto(decimal Valor, DateTime Vencimento, DateTime DataPagamento, FormaPagamentoTypes FormaPagamento, AlunoOutputDto Aluno);
    public record MensalidadeOutputDto(Guid Id, decimal Valor, DateTime Vencimento, DateTime DataPagamento, FormaPagamentoTypes FormaPagamento, AlunoOutputDto Aluno);
}
