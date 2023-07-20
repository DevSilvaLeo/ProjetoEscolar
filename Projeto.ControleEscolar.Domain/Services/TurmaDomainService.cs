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
    public class TurmaDomainService : ITurmaDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TurmaDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Insert(Turma obj)
        {
            _unitOfWork.TurmaRepository.Create(obj);
        }

        public void Update(Turma obj)
        {
            _unitOfWork.TurmaRepository.Update(obj);
        }

        public void Delete(Turma obj)
        {
            _unitOfWork.TurmaRepository.Delete(obj);
        }

        public Task<IList<Turma>> GetAll()
        {
            return _unitOfWork.TurmaRepository.GetAll();
        }

        public async Task<Turma> GetById(Guid id)
        {
            return await _unitOfWork.TurmaRepository.Get(id);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
