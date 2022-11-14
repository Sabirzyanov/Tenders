using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Tenders.Data;

/// <summary>
/// Класс, релизующий соединение с БД
/// </summary>
/// <typeparam name="T"></typeparam>
public class MongoConnection<T>
{
    public IMongoDatabase Database { get; set; }
    public IMongoCollection<T> Collection { get; }

    public MongoConnection(IConfiguration configuration)
    {
        Database = new MongoClient(configuration["ConnectionInfos:ConnectionString"]).GetDatabase(configuration["ConnectionInfos:DbName"]);
        Collection = Database.GetCollection<T>(configuration[$"ConnectionInfos:{typeof(T).Name}CollectionName"]);
    }
}