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
    public class ProfessorDomainService : IProfessorDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProfessorDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Insert(Professor obj)
        {
            _unitOfWork.ProfessorRepository.Create(obj);
        }

        public void Update(Professor obj)
        {
            _unitOfWork.ProfessorRepository.Update(obj);
        }

        public void Delete(Professor obj)
        {
            _unitOfWork.ProfessorRepository.Delete(obj);
        }

        public async Task<IList<Professor>> GetAll()
        {
            return await _unitOfWork.ProfessorRepository.GetAll();
        }

        public async Task<Professor> GetById(Guid id)
        {
            return await _unitOfWork.ProfessorRepository.Get(id);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
