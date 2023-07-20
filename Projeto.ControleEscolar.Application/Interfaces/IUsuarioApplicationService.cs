﻿using Projeto.ControleEscolar.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Application.Interfaces
{
    public interface IUsuarioApplicationService
    {
        Task CriarUsuario(UsuarioInputDto usuario);
        Task AtualizarUsuario(UsuarioOutputDto usuario);
        Task<UsuarioOutputDto> RemoverUsuario(int id);
        Task<IList<UsuarioOutputDto>> ListarUsuarios();
        Task<UsuarioOutputDto> ListarPorId(int id);
    }
}
