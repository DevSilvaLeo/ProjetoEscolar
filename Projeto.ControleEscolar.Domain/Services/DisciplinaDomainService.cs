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
    public class DisciplinaDomainService : IDisciplinaDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DisciplinaDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Insert(Disciplina obj)
        {
            _unitOfWork.DisciplinaRepository.Create(obj);
        }

        public void Update(Disciplina obj)
        {
            _unitOfWork.DisciplinaRepository.Update(obj);
        }

        public void Delete(Disciplina obj)
        {
            _unitOfWork.DisciplinaRepository.Delete(obj);
        }

        public async Task<IList<Disciplina>> GetAll()
        {
            return await _unitOfWork.DisciplinaRepository.GetAll();
        }

        public async Task<Disciplina> GetById(Guid id)
        {
            return await _unitOfWork.DisciplinaRepository.Get(id);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
