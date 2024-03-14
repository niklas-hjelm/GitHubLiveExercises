namespace GitHubLiveExercises.Common.Interfaces;

public interface IRepository<TEntity, TId>
{
    public Task<IEnumerable<TEntity>> GetAllAsync();

    public Task<TEntity> GetByIdAsync(TId id);

    public Task AddAsync(TEntity entity);

    public Task UpdateAsync(TEntity entity);
    public Task DeleteAsync(TEntity entity);

}