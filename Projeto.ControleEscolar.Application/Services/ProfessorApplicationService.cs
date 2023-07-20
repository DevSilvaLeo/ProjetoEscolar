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
    public class ProfessorApplicationService : IProfessorApplicationService
    {
        private readonly IProfessorDomainService _service;
        private readonly IMapper _mapper;

        public ProfessorApplicationService(IProfessorDomainService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task Inserir(ProfessorInputDto entity)
        {
            var professor = _mapper.Map<Professor>(entity);
            var validate = professor.Validate;

            if (!validate.IsValid)
                throw new ValidationException(validate.Errors);

            _service.Insert(professor);
        }

        public async Task Atualizar(ProfessorOutputDto entity)
        {
            var professor = _mapper.Map<Professor>(entity);
            var validate = professor.Validate;

            if (!validate.IsValid)
                throw new ValidationException(validate.Errors);

            _service.Update(professor);
        }

        public async Task<ProfessorOutputDto> Remover(Guid id)
        {
            var professor = await _service.GetById(id);
            DomainException.When(
                professor == null,
                "Professor não encontrado com id informado."
                );

            if(professor != null)
                _service.Delete(professor);

            return _mapper.Map<ProfessorOutputDto>(professor);
        }

        public async Task<IList<ProfessorOutputDto>> ListarTodos()
        {
            var professores = await _service.GetAll();
            DomainException.When(
                    professores == null,
                    "Professores não encontrados."
                );

            return _mapper.Map<IList<ProfessorOutputDto>>(professores).ToList();
        }

        public async Task<ProfessorOutputDto> ListarPorId(Guid id)
        {
            var professor = await _service.GetById(id);
            DomainException.When(
                professor == null,
                "Professor não encontrado com id informado."
                );

            return _mapper.Map<ProfessorOutputDto>(professor);
        }
    }
}
