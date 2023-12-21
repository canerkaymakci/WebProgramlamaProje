using System;
using WebProgramlamaProje.Models;

namespace WebProgramlamaProje.Repository
{
	public interface IBaseRepository<TEntity> where TEntity:class,IBaseEntity
	{
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(Guid Id);
        Task<List<TEntity>> GetAllAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(Guid Id);

    }
}

