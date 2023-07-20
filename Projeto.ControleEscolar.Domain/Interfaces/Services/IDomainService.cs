using Projeto.ControleEscolar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Domain.Interfaces.Services
{
    public interface IDomainService<TEntity, Tkey> : IDisposable
        where TEntity : class
    {
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);
        Task<IList<TEntity>> GetAll();
        Task<TEntity> GetById(Tkey id);
    }
}
