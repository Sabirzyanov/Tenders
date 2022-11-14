using MongoDB.Driver;
using Tenders.Core.Entities;
using Tenders.Data.DbModels;
using Tenders.Data.DbModels.BaseModel;

namespace Tenders.Data.Resources;

/// <summary>
/// Базовая реализация репозитория
/// </summary>
/// <typeparam name="TModel">Модель, загружающаяся в БД</typeparam>
/// <typeparam name="TEntity">Сущность</typeparam>
public abstract class BaseRepository<TModel, TEntity> : IRepository<TEntity>
    where TModel : BaseDbModel
    where TEntity : BaseEntity
{
    private MongoConnection<TModel> _dbConnection;

    public BaseRepository(MongoConnection<TModel> mongoConnection)
    {
        _dbConnection = mongoConnection;
    }

    public async Task Save(TEntity entity)
    {
        try
        {
            await _dbConnection.Collection.InsertOneAsync(CastEntityToModel(entity));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task Update(TEntity entity)
    {
        try
        {
            await _dbConnection.Collection.ReplaceOneAsync(x => x.Id == entity.Id, CastEntityToModel(entity));
        }
        catch (Exception e)
        {
            throw;
        }
    }

    public async Task Delete(string id)
    {
        try
        {
            await _dbConnection.Collection.DeleteOneAsync(x => x.Id == id);
        }
        catch (Exception e)
        {
            throw;
        }
    }

    public async Task<IEnumerable<TEntity>> GetAllEntities()
    {
        try
        {
            return (await _dbConnection.Collection.FindAsync(_ => true)).ToList().Select(x => CastModelToEntity(x));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<TEntity> GetEntityById(string? id)
    {
        return CastModelToEntity((await _dbConnection.Collection.FindAsync(x => x.Id == id)).FirstOrDefault());
    }

    public async Task<TEntity> GetEntityByName(string name)
    {
        return CastModelToEntity((await _dbConnection.Collection.FindAsync(x => (x as UserDbModel)!.Login == name)).FirstOrDefault());
    }

    protected abstract TEntity CastModelToEntity(TModel model);
    protected abstract TModel CastEntityToModel(TEntity entity);
}