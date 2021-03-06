﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace IntelliSenseExtender.Extensions
{
    public static class SyntaxTokenExtensions
    {
        public static bool IsMemberAccessContext(this SyntaxToken currentToken, out ExpressionSyntax accessedExpressionSyntax)
        {
            accessedExpressionSyntax = null;

            var parentNode = currentToken.Parent;
            var memberAccessNode = parentNode as MemberAccessExpressionSyntax
                ?? parentNode?.Parent as MemberAccessExpressionSyntax;
            if (memberAccessNode != null)
            {
                accessedExpressionSyntax = memberAccessNode.Expression;
            }

            return accessedExpressionSyntax != null;
        }

        public static bool IsObjectCreationContext(this SyntaxToken currentToken, out ObjectCreationExpressionSyntax creationExpressionSyntax)
        {
            creationExpressionSyntax = null;

            if (currentToken.Kind() == SyntaxKind.NewKeyword)
            {
                creationExpressionSyntax = currentToken.Parent as ObjectCreationExpressionSyntax;
            }
            return creationExpressionSyntax != null;
        }
    }
}
