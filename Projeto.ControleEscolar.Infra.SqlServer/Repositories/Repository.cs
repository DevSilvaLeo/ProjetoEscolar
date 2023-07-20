using Microsoft.EntityFrameworkCore;
using Projeto.ControleEscolar.Domain.Core;
using Projeto.ControleEscolar.Infra.SqlServer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.ControleEscolar.Infra.SqlServer.Repositories
{
    public class Repository<T, TKey> : IRepository<T, TKey>
        where T : class
    {
        private readonly SqlServerContext _context;

        protected Repository(SqlServerContext context)
        {
            _context = context;
        }

        public void Create(T obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            _context.Update(obj);
            _context.SaveChanges();
        }

        public void Delete(T obj)
        {
            _context.Remove(obj);
            _context.SaveChanges();
        }

        public async Task<IList<T>> GetAll()
        { 
            var usuarios = await _context.Set<T>().ToListAsync();
            //return await _context.Set<T>().ToListAsync();
            return usuarios;
        }

        public async Task<T> Get(TKey id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
    }
}
