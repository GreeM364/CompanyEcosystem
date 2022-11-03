using System.Linq.Expressions;


namespace CompanyEcosystem.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);

        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string? includeString = null,
            bool disableTracking = true);

        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            List<Expression<Func<TEntity, object>>>? includes = null,
            bool disableTracking = true);

        Task<TEntity?> GetByIdAsync(int id);
        Task<TEntity?> GetFirstAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
    }
}
