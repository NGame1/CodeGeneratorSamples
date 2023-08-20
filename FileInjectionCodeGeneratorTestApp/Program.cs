namespace FileInjectionCodeGeneratorTestApp;

internal class Program
{
    static void Main(string[] args)
    {
        var contentXMLFile = new ContentXMLFile();
        var resourceXMLFile = new ResourceXMLFile();
        Console.WriteLine(contentXMLFile.HelloWorld);
        Console.WriteLine(resourceXMLFile.HelloWorld);
    }
}
