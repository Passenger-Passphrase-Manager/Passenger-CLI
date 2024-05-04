namespace Passenger
{
  public class FileSystem
  {
    private static void Exceptions(Exception exception)
    {
      switch (exception)
      {
        case FileNotFoundException:
          Console.WriteLine("passenger: data file not found");
          Environment.Exit(1); break;
        case UnauthorizedAccessException:
          Console.WriteLine("passenger: data file access denied");
          Environment.Exit(126); break;
        case IOException:
          Console.WriteLine("passenger: data file input/output error");
          Environment.Exit(1); break;
        default:
          Console.WriteLine("passenger: unexpected error while accessing data file");
          Environment.Exit(2); break;
      }
    }
    public static string Read(string fileName)
    {
      try
      {
        if (!File.Exists(fileName)) return "";
        return EnDeCoder.Decode(new StreamReader(fileName).ReadToEnd());
      }
      catch (Exception exception) { Exceptions(exception); throw; }
    }
    public static void Write(string fileName, string data)
    {
      try { File.WriteAllText(fileName, EnDeCoder.Encode(data)); }
      catch (Exception exception) { Exceptions(exception); }
    }
  }
}