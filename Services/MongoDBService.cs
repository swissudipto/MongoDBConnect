using MongoExample.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDBConnect.Models;

namespace MongoExample.Services;

public class MongoDBService
{
    private readonly IMongoCollection<Username> UsernameCollection;
    public MongoDBService(IOptions<MongoDBSettings> mongoDBsettings)
    {
        MongoClient client = new MongoClient(mongoDBsettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBsettings.Value.DatabaseName);
        UsernameCollection = database.GetCollection<Username>(mongoDBsettings.Value.CollectionName);
    }

    public async Task CreateUser(Username user)
    {
        await UsernameCollection.InsertOneAsync(user);
        return;
    }

    public async Task<List<Username>> GetAsync()
    {
        return await UsernameCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<List<Username>> GetSpecificUser(string id)
    {
        return await UsernameCollection.Find(x => x.Id == id).ToListAsync();
    }

    public async Task Updateasync(string id, Username username)
    {
        await UsernameCollection.ReplaceOneAsync(x => x.Id == id, username);
    }

    public async Task DeleteAsync(string id)
    {
        FilterDefinition<Username> filter = Builders<Username>.Filter.Eq("Id", id);
        await UsernameCollection.DeleteOneAsync(filter);
    }

}

