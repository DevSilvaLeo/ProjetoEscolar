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
    public class AlunoDomainService : IAlunoDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AlunoDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Insert(Aluno obj)
        {
            _unitOfWork.AlunoRepository.Create(obj);
        }

        public void Update(Aluno obj)
        {
            _unitOfWork.AlunoRepository.Update(obj);
        }

        public void Delete(Aluno obj)
        {
            _unitOfWork.AlunoRepository.Delete(obj);
        }

        public async Task<IList<Aluno>> GetAll()
        {
            return await _unitOfWork.AlunoRepository.GetAll();
        }

        public async Task<Aluno> GetById(Guid id)
        {
            return await _unitOfWork.AlunoRepository.Get(id);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
