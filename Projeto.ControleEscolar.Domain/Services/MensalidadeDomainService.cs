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
    public class MensalidadeDomainService : IMensalidadeDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MensalidadeDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Insert(Mensalidade obj)
        {
            _unitOfWork.MensalidadeRepository.Create(obj);
        }

        public void Update(Mensalidade obj)
        {
            _unitOfWork.MensalidadeRepository.Update(obj);
        }

        public void Delete(Mensalidade obj)
        {
            _unitOfWork.MensalidadeRepository.Delete(obj);
        }

        public async Task<IList<Mensalidade>> GetAll()
        {
            return await _unitOfWork.MensalidadeRepository.GetAll();
        }

        public async Task<Mensalidade> GetById(Guid id)
        {
            return await _unitOfWork.MensalidadeRepository.Get(id);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
