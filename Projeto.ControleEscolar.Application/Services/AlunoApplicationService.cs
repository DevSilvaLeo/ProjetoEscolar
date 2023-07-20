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
    public class AlunoApplicationService : IAlunoAplicationService
    {
        private readonly IAlunoDomainService _service;
        private readonly IMapper _mapper;

        public AlunoApplicationService(IAlunoDomainService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task Inserir(AlunoInputDto entity)
        {
            var aluno = _mapper.Map<Aluno>(entity);
            var validate = aluno.Validate;
            if(!validate.IsValid)
                throw new ValidationException(validate.Errors);
            
            _service.Insert(aluno);
        }

        public async Task Atualizar(AlunoOutputDto entity)
        {
            var aluno = _mapper.Map<Aluno>(entity);
            var validate = aluno.Validate;
            if (!validate.IsValid)
                throw new ValidationException(validate.Errors);

            _service.Update(aluno);
        }

        public async Task<AlunoOutputDto> Remover(Guid id)
        {
            var aluno = await _service.GetById(id);
            DomainException.When(
                    aluno == null,
                    "Aluno informado não encontrado."
                );

            if (aluno != null)
                _service.Delete(aluno);

            return _mapper.Map<AlunoOutputDto>(aluno);
        }

        public async Task<IList<AlunoOutputDto>> ListarTodos()
        {
            var alunos = await _service.GetAll();
            DomainException.When(
                    alunos == null, 
                    "Não existem alunos cadastrados."
                );
            return _mapper.Map<IList<AlunoOutputDto>>(alunos).ToList();
        }

        public async Task<AlunoOutputDto> ListarPorId(Guid id)
        {
            var aluno = await _service.GetById(id);
            DomainException.When(
                    aluno == null,
                    "Não existem alunos cadastrados."
                );
            return _mapper.Map<AlunoOutputDto>(aluno);
        }
    }
}
