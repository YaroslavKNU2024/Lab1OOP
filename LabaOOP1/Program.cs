using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPLab._1
{

	public class Parser
	{
		enum Types { NONE, DELIMETER, NUMBER };
		string s = "";
		string exp;
		int expIdx;
		string token;
		Types tokTypel;
		public string str_error = "";

		public Parser()
		{

		}

		public double ExpressionStart(string expstr)
		{
			double result;
			exp = expstr;
			int l = exp.Length;
			if (exp[l - 1].Equals('+') || exp[l - 1].Equals('-') || exp[l - 1].Equals('/') || exp[l - 1].Equals('*') || exp[l - 1].Equals('%') ||
				exp[l - 1].Equals('|') || exp[l - 1].Equals('^') || exp[l - 1].Equals('>') || exp[l - 1].Equals('<'))
			{
				MessageBox.Show("Last lex should be expression");
				str_error = "Last lex should be expression";
			}
			expIdx = 0;
			try
            {
				GetToken();
				if (token == "")
                {
					str_error = "no expression";
					return 0.0;
                }
				ExpPorivn(out result);
				if (token != "") ;
					MessageBox.Show("Last lex must = 0");
				return result;
            }
			catch(Exception ex)
            {
				MessageBox.Show(ex.Message);
				return 0.0;
            }
		}
		void Expr(out double result)
        {
			int varIdx;
			Types ttokType;
			string temptoken;
			ExpPorivn(out result);
        }

		void ExpPorivn(out double result)
        {
			string op;
			double partialResult;

			ExpPlusMin(out result);
			while((op = token) == ">" || op == "<")
            {
				GetToken();
				ExpPlusMin(out partialResult);
				switch (op)
                {
					case ">":
						if (result > partialResult) result = 1.0;
						else result = 0.0;
						break;
					case "<":
						if (result < partialResult) result = 1.0;
						else result = 0.0;
						break;
                }
            }

        }

		void ExpPlusMin(out double result)
        {
			string op;
			double partialResult;

			ExpMultdiv(out result);
			while((op = token) == "+" || op == "-")
            {
				GetToken();
				ExpMultdiv(out partialResult);
				switch (op)
                {
					case "-":
						result = result - partialResult;
						break;
					case "+":
						result = result + partialResult;
						break;

                }
            }
        }
		void ExpMultdiv(out double result)
        {
			string op;
			double partialResult = 0.0;
			ExpStepin(out result);
			while (())

        }
	}


	static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
