using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MasVeterinarias.Domain.Interfaces;
using MasVeterinarias.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq.Expressions;
using MasVeterinarias.Infraestructure.Data;

namespace MasVeterinarias.Infraestructure.Repositories
{
    public class SQLRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MasVeterinariasDBContext _context;
        private DbSet<T> _entities;

        public SQLRepository(MasVeterinariasDBContext context)
        {
            this._context = context;
            this._entities = context.Set<T>();
        }
        public async Task Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity");
            _entities.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("Entity");
            var entity = await GetById(id);
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return await _entities.Where(expression).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity");
            if (entity.Id <= 0)
                throw new ArgumentNullException("Entity");
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
