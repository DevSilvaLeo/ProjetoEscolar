using Projeto.ControleEscolar.Domain.Entities;
using Projeto.ControleEscolar.Domain.Interfaces.Repository;
using Projeto.ControleEscolar.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Domain.Services
{
    public class UsuarioDomainService : IUsuarioDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Insert(Usuario obj)
        {
            _unitOfWork.UsuarioRepository.Create(obj);
        }

        public void Update(Usuario obj)
        {
            _unitOfWork.UsuarioRepository.Update(obj);
        }

        public void Delete(Usuario obj)
        {
            _unitOfWork.UsuarioRepository.Delete(obj);
        }

        public Usuario GetUserByCredentials(string usuario, string senha)
        {
            return _unitOfWork.UsuarioRepository.GetUserByCredentials(usuario, senha);
        }

        public bool EmailExists(string email)
        {
            return _unitOfWork.UsuarioRepository.EmailExists(email);
        }

        public async Task<IList<Usuario>> GetAll()
        {
            return await _unitOfWork.UsuarioRepository.GetAll();
        }

        public async Task<Usuario> GetById(int id)
        {
            return await _unitOfWork.UsuarioRepository.Get(id);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
