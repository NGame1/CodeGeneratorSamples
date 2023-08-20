namespace XMLCodeGeneratorTestApp;

internal class Program
{
    static void Main(string[] args)
    {
        var XMLParser = new TestXMLFileClass();
        Console.WriteLine(XMLParser.HelloWorld);
        Console.WriteLine(XMLParser.HelloWorldInPersian);
    }
}
