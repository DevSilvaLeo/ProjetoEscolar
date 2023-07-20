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
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UsuarioInputDto, Usuario>()
                .ReverseMap();

            CreateMap<UsuarioOutputDto, Usuario>() 
                .ReverseMap();
        }
    }
}
