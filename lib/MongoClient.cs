using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.IO;

public class MongoClientProvider
{
  private readonly MongoClient _client;

  public MongoClientProvider()
  {
    // Set up configuration sources
    var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddUserSecrets<Program>() // Add this line
    .AddEnvironmentVariables()
    .Build();

    // Retrieve the MongoDB connection string
    var connectionUri = Environment.GetEnvironmentVariable("MONGODB_URI")
      ?? throw new InvalidOperationException("Connection string is missing.");

    var settings = MongoClientSettings.FromConnectionString(connectionUri);
    settings.ServerApi = new ServerApi(ServerApiVersion.V1);

    _client = new MongoClient(settings);

    // Ping to check the connection
    try
    {
      var result = _client.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
      Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");
    }
    catch (MongoException ex)
    {
      Console.WriteLine($"MongoDB connection error: {ex.Message}");
    }
    catch (Exception ex)
    {
      Console.WriteLine($"An unexpected error occurred: {ex.Message}");
    }
  }

  // This method returns the MongoClient instance
  public MongoClient GetClient()
  {
    return _client;
  }
}
