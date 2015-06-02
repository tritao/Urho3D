using CppSharp;
using CppSharp.AST;
using CppSharp.Passes;
using System;
using System.IO;
using System.Linq;

namespace Mono
{
    class UrhoBindingsGen : ILibrary
    {
        public void Setup(Driver driver)
        {
            var options = driver.Options;
            options.LibraryName = "Urho";
            options.OutputDir = "Urho";
            options.Verbose = false;

            options.SetupXcode();

            options.addIncludeDirs(Path.GetFullPath("../Source/Urho3D"));
            options.Headers.Add("Engine/Application.h");

        }

        public void SetupPasses(Driver driver)
        {
            //driver.TranslationUnitPasses.AddPass(new ClearCommentsPass());
        }

        public void Preprocess(Driver driver, ASTContext ctx)
        {
            // Remove when CppSharp binaries are up-to-date.
            //ctx.IgnoreClassWithName("VariantValue");

            // Remove when comment bug is fixed.
            //ctx.IgnoreClassWithName("HashBase");

        }

        public void Postprocess(Driver driver, ASTContext ctx)
        {
        }

        static class Program
        {
            public static void Main(string[] args)
            {
                ConsoleDriver.Run(new UrhoBindingsGen());
            }
        }
    }

    class ClearCommentsPass : TranslationUnitPass
    {
        public override bool VisitDeclaration(Declaration decl)
        {
            //decl.Comment = null;
            return false;
        }
    }
}
