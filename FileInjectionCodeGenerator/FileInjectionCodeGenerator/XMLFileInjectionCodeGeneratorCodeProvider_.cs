using Microsoft.CodeAnalysis;
using System.Diagnostics;
using System.Xml;
using System.Linq;
using System.Text;
using System.IO;

namespace FileInjectionCodeGenerator;

[Generator]
internal class XMLFileInjectionCodeGeneratorCodeProvider_ : ISourceGenerator
{
    public void Execute(GeneratorExecutionContext context)
    {
        // AdditionalFiles passed from XMLCodeGeneratorTestApp.csproj you can add or remove additional files there to access them here in compile time

        foreach (var xmlFile in context.AdditionalFiles)
        {
            XmlDocument xmlDoc = new();
            string text = xmlFile.GetText(context.CancellationToken).ToString();
            try
            {
                xmlDoc.LoadXml(text);
            }
            catch
            {
                return;
            }

            var NodeValues = xmlDoc.SelectNodes("//Message")
                            .Cast<XmlElement>()
                            .Select(node => new
                            {
                                Name = node.GetAttribute("name"),
                                Value = node.InnerText
                            })
                            .ToArray()
                            ;

            StringBuilder sb = new();
            StringBuilder properties = new();
            for (int i = 0; i < NodeValues.Length; i++)
            {
                var Element = NodeValues.ElementAtOrDefault(i);
                if (Element != null)
                {
                    properties.AppendLine($@"   public string {Element.Name} {{ get; set; }} = ""{Element.Value}""; ");
                }
            }

            var fileExt = Path.GetExtension(xmlFile.Path);
            var fileName = Path.GetFileName(xmlFile.Path);
            var className = fileName.Replace(fileExt, string.Empty);

            sb.Append($@"
namespace {context.Compilation.AssemblyName};

public class {className}
{{
    // Properties will be generated here
{properties}
}}
");
            context.AddSource($"{className}.cs", sb.ToString());
        }
    }

    public void Initialize(GeneratorInitializationContext context)
    {
//#if DEBUG
//        if (!Debugger.IsAttached)
//        {
//            Debugger.Launch();
//        }
//#endif
    }
}
