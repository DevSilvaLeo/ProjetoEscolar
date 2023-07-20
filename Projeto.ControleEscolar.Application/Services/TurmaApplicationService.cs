using AutoMapper;
using FluentValidation;
using Projeto.ControleEscolar.Application.Dtos;
using Projeto.ControleEscolar.Application.Interfaces;
using Projeto.ControleEscolar.Domain.Core;
using Projeto.ControleEscolar.Domain.Entities;
using Projeto.ControleEscolar.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Application.Services
{
    public class TurmaApplicationService : ITurmaApplicationService
    {
        private readonly ITurmaDomainService _service;
        private readonly IMapper _mapper;

        public TurmaApplicationService(ITurmaDomainService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task Inserir(TurmaInputDto entity)
        {
            var turma = _mapper.Map<Turma>(entity);
            var validate = turma.Validate;

            if (!validate.IsValid)
                throw new ValidationException(validate.Errors);

            _service.Insert(turma);
        }

        public async Task Atualizar(TurmaOutputDto entity)
        {
            var turma = _mapper.Map<Turma>(entity);
            var validate = turma.Validate;

            if (!validate.IsValid)
                throw new ValidationException(validate.Errors);

            _service.Update(turma);
        }

        public async Task<TurmaOutputDto> Remover(Guid id)
        {
            var turma = await _service.GetById(id);
            DomainException.When(
                    turma == null,
                    "Não foi encontrada nenhuma turma para ID informado."
                );

            if (turma != null)
                _service.Delete(turma);

            return _mapper.Map<TurmaOutputDto>(turma);
        }

        public async Task<IList<TurmaOutputDto>> ListarTodos()
        {
            var turma = await _service.GetAll();
            DomainException.When(
                    turma == null,
                    "Não foi encontrada nenhuma turma cadastrada."
                );

            return _mapper.Map<IList<TurmaOutputDto>>(turma).ToList();
        }

        public async Task<TurmaOutputDto> ListarPorId(Guid id)
        {
            var turma = await _service.GetById(id);
            DomainException.When(
                    turma == null,
                    "Não foi encontrada nenhuma turma para ID informado."
                );

            return _mapper.Map<TurmaOutputDto>(turma);
        }
    }
}
