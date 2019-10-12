#r "nuget: Microsoft.CodeAnalysis.CSharp, 3.3.1"
using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;



public NamespaceDeclarationSyntax CreateDefaultNamespace()
{
    var level1 = SyntaxFactory.IdentifierName("Ivy");
    var level2 = SyntaxFactory.IdentifierName("Measure");
    var combined = SyntaxFactory.QualifiedName(level1, level2);
    return SyntaxFactory.NamespaceDeclaration(combined).NormalizeWhitespace();
}