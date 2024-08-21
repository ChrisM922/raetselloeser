using System;
using Tesseract;

public class TesseractService
{
  private readonly string _tessDataPath;

  public TesseractService(string tessDataPath)
  {
    _tessDataPath = tessDataPath;
  }

  public string ExtractText(string imagePath)
  {
    try
    {
      using (var engine = new TesseractEngine(_tessDataPath, "deu", EngineMode.Default))
      {
        using (var img = Pix.LoadFromFile(imagePath))
        {
          using (var page = engine.Process(img, "psm=1"))
          {
            return page.GetText();
          }
        }
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine("Error: " + ex.Message);
      return string.Empty;
    }
  }
}