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
    public class AvaliacaoApplicationService : IAvaliacaoApplicationService
    {
        private readonly IAvaliacaoDomainService _service;
        private readonly IMapper _mapper;

        public AvaliacaoApplicationService(IAvaliacaoDomainService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task Inserir(AvaliacaoInputDto entity)
        {
            var avaliacao = _mapper.Map<Avaliacao>(entity);
            var validate = avaliacao.Validate;
            if (!validate.IsValid)
                throw new ValidationException(validate.Errors);

            _service.Insert(avaliacao);
        }

        public async Task Atualizar(AvaliacaoOutputDto entity)
        {
            var avaliacao = _mapper.Map<Avaliacao>(entity);
            var validate = avaliacao.Validate;
            if (!validate.IsValid)
                throw new ValidationException(validate.Errors);

            _service.Update(avaliacao);
        }

        public async Task<AvaliacaoOutputDto> Remover(int id)
        {
            var avaliacao = await _service.GetById(id);
            DomainException.When(
                avaliacao == null, 
                "Avaliação não encontrada com o ID informado."
              );
            _service.Delete(avaliacao);

            return _mapper.Map<AvaliacaoOutputDto>(avaliacao);
        }

        public async Task<IList<AvaliacaoOutputDto>> ListarTodos()
        {
            var avaliacoes = await _service.GetAll();
            DomainException.When(
                avaliacoes == null,
                "Avaliação não encontrada com o ID informado."
              );

            return _mapper.Map<IList<AvaliacaoOutputDto>>(avaliacoes);
        }

        public async Task<AvaliacaoOutputDto> ListarPorId(int id)
        {
            var avaliacao = await _service.GetById(id);
            DomainException.When(
                avaliacao == null,
                "Avaliação não encontrada com o ID informado."
              );

            return _mapper.Map<AvaliacaoOutputDto>(avaliacao);
        }
    }
}
