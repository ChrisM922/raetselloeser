using MongoDB.Driver;
using MongoDB.Bson;

public class MongoClientProvider
{
  private readonly MongoClient _client;

  public MongoClientProvider()
  {
    const string connectionUri = "mongodb+srv://raetselloeser:o30qNGN3cub70Axn@raetselloeser.4nx8t.mongodb.net/?retryWrites=true&w=majority&appName=Raetselloeser";
    var settings = MongoClientSettings.FromConnectionString(connectionUri);
    settings.ServerApi = new ServerApi(ServerApiVersion.V1);
    _client = new MongoClient(settings);

    // Ping to check the connection
    try
    {
      var result = _client.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
      Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex);
    }
  }

  // This method returns the MongoClient instance
  public MongoClient GetClient()
  {
    return _client;
  }
}
