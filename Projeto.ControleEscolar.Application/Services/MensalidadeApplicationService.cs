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
    public class MensalidadeApplicationService : IMensalidadeApplicationService
    {
        private readonly IMensalidadeDomainService _service;
        private readonly IMapper _mapper;

        public MensalidadeApplicationService(IMensalidadeDomainService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task Inserir(MensalidadeInputDto entity)
        {
            var mensalidade = _mapper.Map<Mensalidade>(entity);
            var validate = mensalidade.Validate;
            if (!validate.IsValid)
                throw new ValidationException(validate.Errors);
            
            _service.Insert(mensalidade);
        }
        public async Task Atualizar(MensalidadeOutputDto entity)
        {
            var mensalidade = _mapper.Map<Mensalidade>(entity);
            var validate = mensalidade.Validate;
            if (!validate.IsValid)
                throw new ValidationException(validate.Errors);

            _service.Update(mensalidade);
        }

        public async Task<MensalidadeOutputDto> Remover(Guid id)
        {
            var mensalidade = await _service.GetById(id);
            DomainException.When
                (mensalidade == null, 
                    "Não existe mensalidade com o ID informado."
                   );

            _service.Delete(mensalidade);

            return _mapper.Map<MensalidadeOutputDto>(mensalidade);
        }

        public async Task<IList<MensalidadeOutputDto>> ListarTodos()
        {
            var mensalidades = await _service.GetAll();
            DomainException.When(
                mensalidades == null, 
                "Não existem mensalidades cadastradas"
               );

            return _mapper.Map<IList<MensalidadeOutputDto>>(mensalidades);
        }

        public async Task<MensalidadeOutputDto> ListarPorId(Guid id)
        {
            var mensalidade = await _service.GetById(id);
            DomainException.When(
                mensalidade == null, 
                "Não existe mensalidade com o ID informado."
               );

            return _mapper.Map<MensalidadeOutputDto>(mensalidade);
        }
    }
}
