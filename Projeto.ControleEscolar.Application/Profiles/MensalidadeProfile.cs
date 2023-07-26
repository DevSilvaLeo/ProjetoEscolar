using AutoMapper;
using Projeto.ControleEscolar.Application.Dtos;
using Projeto.ControleEscolar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Application.Profiles
{
    public class MensalidadeProfile : Profile
    {
        public MensalidadeProfile()
        {
            CreateMap<MensalidadeInputDto, Mensalidade>()
                .ReverseMap();
            CreateMap<MensalidadeOutputDto, Mensalidade>()
                .ReverseMap();
        }
    }
}
