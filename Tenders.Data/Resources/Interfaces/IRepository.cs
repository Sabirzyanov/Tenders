using MongoDB.Driver;

namespace Tenders.Data.Resources;

public interface IRepository<TEntity>
{
    public Task Save(TEntity entity);
    public Task Update(TEntity entity);
    public Task Delete(string id);
    
    public Task<IEnumerable<TEntity>> GetAllEntities();
    public Task<TEntity> GetEntityById(string? id);
    public Task<TEntity> GetEntityByName(string name);


}