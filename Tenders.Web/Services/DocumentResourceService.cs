using MongoDB.Bson;
using MongoDB.Driver.GridFS;
using Tenders.Core.Entities.Document;
using Tenders.Core.Enums;
using Tenders.Data;
using Tenders.Data.DbModels;

namespace Tenders.Web.Services;

public class DocumentResourceService
{
    private readonly MongoProvider<BaseDocument> _mongoProvider;
    private readonly IGridFSBucket _gridFs;
    
    public DocumentResourceService(MongoProvider<BaseDocument> mongoProvider, MongoConnection<DocumentDbModel> connection)
    {
        _gridFs = new GridFSBucket(connection.Database);
        _mongoProvider = mongoProvider;
    }

    public async Task<BaseDocument> GetDocument(string id)
    {
        return await _mongoProvider.GetEntityById(id);
    }

    public async Task<IEnumerable<BaseDocument?>> GetDocumentsByProjectId(string projectId)
    {
        return (await _mongoProvider.GetAll()).Where(x => x.ProjectId == projectId);
    }

    public async Task<IResult> SaveDocument(BaseDocument entity)
    {
        await _mongoProvider.Save(entity);
        return Results.Ok();
    }

    public async Task<IResult> UpdateDocument(BaseDocument entity)
    {
        await _mongoProvider.Update(entity);
        return Results.Ok();
    }

    public async Task<string> SaveFile(string name, Stream ms)
    {
        return (await _gridFs.UploadFromStreamAsync(name, ms)).ToString();
    }

    public async Task DownloadFile(string fileId, FileStream stream)
    {
        await _gridFs.DownloadToStreamAsync(new ObjectId(fileId), stream);
    }
}