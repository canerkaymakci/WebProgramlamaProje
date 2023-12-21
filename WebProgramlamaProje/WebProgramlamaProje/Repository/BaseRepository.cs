using System;
using Microsoft.EntityFrameworkCore;
using WebProgramlamaProje.Models;

namespace WebProgramlamaProje.Repository
{
	public abstract class BaseRepository<TEntity,TContext>: IBaseRepository<TEntity> where TEntity:class, IBaseEntity where TContext:DbContext
	{
        private readonly TContext _context;

		public BaseRepository(TContext context)
		{
            _context = context;
		}

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> DeleteAsync(Guid Id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(Id);
            if (entity == null)
                return entity;
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid Id)
        {
            return await _context.Set<TEntity>().FindAsync(Id);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}

