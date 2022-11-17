using MongoDB.Driver;
using Tenders.Core.Entities;
using Tenders.Data.Resources;

namespace Tenders.Data;

/// <summary>
/// Основной класс для работы с БД
/// </summary>
/// <typeparam name="TEntity">Сущность</typeparam>
public class MongoProvider<TEntity>
{
    private readonly IRepository<TEntity> _repository;

    public MongoProvider(IRepository<TEntity> rep)
    {
        _repository = rep;
    }

    public async Task Save(TEntity entity)
    {
        await _repository.Save(entity);
    }

    public async Task Update(TEntity entity)
    {
        await _repository.Update(entity);
    }

    public async Task Delete(string id)
    {
        await _repository.Delete(id);
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await _repository.GetAllEntities();
    }

    public async Task<TEntity> GetEntityById(string? id)
    {
        return await _repository.GetEntityById(id);
    }

}