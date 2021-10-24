using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaOOP1
{
    public static class Calculator
    {
        public static double Evaluate(string expression)
        {
            var lexer = new TestExcelLexer(new AntlrInputStream(expression));
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(new ThrowExceptionErrorListener());

            var tokens = new CommonTokenStream(lexer);
            var parser = new TestExcelParser(tokens);

            var tree = parser.compileUnit();

            var visitor = new TestExcelVisitor();

            double dd = visitor.Visit(tree);
            return dd;
        }
    }
}
