using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CompiledFilesCodeGenerator;

[Generator]
internal class CompiledFilesCodeProvider : ISourceGenerator
{
    public void Execute(GeneratorExecutionContext context)
    {
        var SyntaxTrees = context.Compilation.SyntaxTrees;
        foreach (var STItem in SyntaxTrees)
        {
            var fileName = Path.GetFileName(STItem.FilePath);
            var codeBehind = STItem.GetText(context.CancellationToken);
            // Here you can access all files and the contents that are present in the compile time. 
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
