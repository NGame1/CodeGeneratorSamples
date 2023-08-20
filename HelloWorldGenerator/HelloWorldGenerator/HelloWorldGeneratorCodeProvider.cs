using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeRefactorings;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Rename;
using Microsoft.CodeAnalysis.Text;
using System.Collections.Generic;
using System.Composition;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HelloWorldGenerator
{
    // TODO : For using Source generators in our project we need to add a property to our .csproj called <EnforceExtendedAnalyzerRules> and set it to true
    [Generator]
    public class HelloWorldGenerator : ISourceGenerator
    {
        #region ISourceGenerator Interface Implementations
        public void Execute(GeneratorExecutionContext context)
        {
            // Generate the codes in compilation time !
            StringBuilder sb = new StringBuilder();
            sb.Append($@"
using System;
namespace CodeGeneratedHelloWorld
{{

    public class HelloWorld
    {{
        public static void SayHello()
        {{
            Console.WriteLine(""This is a Hello World from the automatic code generator!"");
        }}
    }}
}}
");
            context.AddSource("CodeGeneratedHelloWorld.cs", sb.ToString());
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            // TODO: Uncomment this line to debug the code generator
//#if DEBUG
//            if (!Debugger.IsAttached)
//            {
//                Debugger.Launch();
//            }
//#endif
        }
        #endregion ISourceGenerator Interface Implementations
    }
}