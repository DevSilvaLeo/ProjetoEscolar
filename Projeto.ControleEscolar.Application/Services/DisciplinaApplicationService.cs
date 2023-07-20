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
    public class DisciplinaApplicationService : IDisciplinaApplicationService
    {
        private readonly IDisciplinaDomainService _service;
        private IMapper _mapper;

        public DisciplinaApplicationService(IDisciplinaDomainService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task Inserir(DisciplinaInputDto entity)
        {
            var disciplina = _mapper.Map<Disciplina>(entity);
            var validate = disciplina.Validate;
            if (!validate.IsValid)
                throw new ValidationException(validate.Errors);
            _service.Insert(disciplina);
        }

        public async Task Atualizar(DisciplinaOutputDto entity)
        {

            var disciplina = _mapper.Map<Disciplina>(entity);
            var validate = disciplina.Validate;
            if (!validate.IsValid)
                throw new ValidationException(validate.Errors);

            _service.Update(disciplina);
        }

        public async Task<DisciplinaOutputDto> Remover(Guid id)
        {
            var disciplina = await _service.GetById(id);
            DomainException.When(
                    disciplina == null,
                    "Não foi encontrada nenhuma disciplina para ID informado."
                );

            if(disciplina != null)
                _service.Delete(disciplina);

            return _mapper.Map<DisciplinaOutputDto>(disciplina);
        }

        public async Task<IList<DisciplinaOutputDto>> ListarTodos()
        {
            var disciplinas = await _service.GetAll();
            DomainException.When(
                    disciplinas == null,
                    "Não existem disciplinas cadastradas"
                );

            return _mapper.Map<IList<DisciplinaOutputDto>>(disciplinas).ToList();
        }

        public async Task<DisciplinaOutputDto> ListarPorId(Guid id)
        {
            var disciplina = await _service.GetById(id);
            DomainException.When(
                    disciplina == null,
                    "Não existe disciplina cadastrada com o id informado"
                );

            return _mapper.Map<DisciplinaOutputDto>(disciplina);
        }
    }
}
