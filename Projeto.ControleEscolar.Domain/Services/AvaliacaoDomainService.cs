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
    public class AvaliacaoDomainService : IAvaliacaoDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AvaliacaoDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Insert(Avaliacao obj)
        {
            _unitOfWork.AvaliacaoRepository.Create(obj);
        }

        public void Update(Avaliacao obj)
        {
            _unitOfWork.AvaliacaoRepository.Update(obj);
        }

        public void Delete(Avaliacao obj)
        {
            _unitOfWork.AvaliacaoRepository.Delete(obj);
        }

        public async Task<IList<Avaliacao>> GetAll()
        {
            return await _unitOfWork.AvaliacaoRepository.GetAll();
        }

        public async Task<Avaliacao> GetById(int id)
        {
            return await _unitOfWork.AvaliacaoRepository.Get(id);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
