using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

public class MongoCrud
{
  private readonly IMongoDatabase _database;
  public MongoCrud(MongoClientProvider clientProvider, string dbName)
  {
    _database = clientProvider.GetClient().GetDatabase(dbName);
  }

  public async Task CreateData()
  {
    try
    {
      var collection = _database.GetCollection<BsonDocument>("raetsel");

      // Check if the collection exists
      if (collection == null)
      {
        await _database.CreateCollectionAsync("raetsel");
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex);
    }
  }

  public async Task GetData()
  {
    try
    {
      var collection = _database.GetCollection<BsonDocument>("raetsel");
      var filter = new BsonDocument();
      var documents = await collection.Find(filter).ToListAsync();
      foreach (var doc in documents)
      {
        Console.WriteLine(doc);
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex);
    }
  }

  public async Task InsertData(string raetsel)
  {
    try
    {
      var collection = _database.GetCollection<BsonDocument>("raetsel");
      var document = new BsonDocument { { "raetsel", raetsel } };
      await collection.InsertOneAsync(document);
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex);
    }
  }

  public async Task DeleteData(string raetsel)
  {
    try
    {
      var collection = _database.GetCollection<BsonDocument>("raetsel");
      var filter = Builders<BsonDocument>.Filter.Eq("raetsel", raetsel);
      await collection.DeleteOneAsync(filter);
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex);
    }
  }

  public async Task UpdateData(string raetsel, string newRaetsel)
  {
    try
    {
      var collection = _database.GetCollection<BsonDocument>("raetsel");
      var filter = Builders<BsonDocument>.Filter.Eq("raetsel", raetsel);
      var update = Builders<BsonDocument>.Update.Set("raetsel", newRaetsel);
      await collection.UpdateOneAsync(filter, update);
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex);
    }
  }
}
