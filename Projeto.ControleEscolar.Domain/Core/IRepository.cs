using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Domain.Core
{
    public interface IRepository<TEntity, TKey>
        where TEntity : class
    {
        void Create(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);
        Task<IList<TEntity>> GetAll();
        Task<TEntity> Get(TKey id);
    }
}
