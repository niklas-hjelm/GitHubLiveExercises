namespace GitHubLiveExercises.Common.Interfaces;

public interface IRepository<TEntity>
{
    public Task<IEnumerable<TEntity>> GetAllAsync();

    public Task<TEntity> GetByIdAsync(int id);

    public Task AddAsync(TEntity entity);

    public Task UpdateAsync(TEntity entity);
    public Task DeleteAsync(TEntity entity);

}