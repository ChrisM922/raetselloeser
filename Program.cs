class Program
{
  static async Task Main(string[] args)
  {
    // initialising the MongoClientProvider
    var mongoClient = new MongoClientProvider();

    // initialising the MongoCrud
    var mongoCrud = new MongoCrud(mongoClient, "raetselloeser");

    // Testing the CRUD operations
    await mongoCrud.CreateData();
    await mongoCrud.InsertData("Test");
    await mongoCrud.GetData();
    await mongoCrud.UpdateData("Test", "Test2");
    await mongoCrud.GetData();
    await mongoCrud.DeleteData("Test2");
    await mongoCrud.GetData();
    await mongoCrud.DeleteData("Test3");
    await mongoCrud.GetData();
    /* await mongoCrud.DeleteData("Test3"); */

    // Testing the TesseractService
    string currentDirectory = Directory.GetCurrentDirectory();
    Console.WriteLine("Current Directory: " + currentDirectory);

    string tessDataPath = Path.Combine(currentDirectory, "lib", "tessdata");
    string testImagePath = Path.Combine(currentDirectory, "DemoRaetzel", "DigitalErstelltesRaetsel.png");

    TesseractService tesseractService = new TesseractService(tessDataPath);

    string extractedText = await Task.Run(() => tesseractService.ExtractText(testImagePath));
    Console.WriteLine("Extracted Text: " + extractedText);
  }
}