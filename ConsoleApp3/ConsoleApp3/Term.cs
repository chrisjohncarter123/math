using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Term
    {
        public int Coef { get; set; }
        public char VariableSymbol { get; set; }
        public int Power { get; set; }
        public const string Pattern = @"[\+\-]?((?<coef>[0-9]+)((?<variable>[a-z]+))(\^((?<power>[0-9]))))";
        public Term()
        {
            Coef = 0;
            VariableSymbol = ' ';
            Power = 0;
        }
        public Term(int coef, char variableSymbol, int power)
        {
            Coef = coef;
            VariableSymbol = variableSymbol;
            Power = power;
        }
        public Term(string input)
        {

            Match m = Regex.Match(input, Pattern, RegexOptions.None);

            int coef = int.Parse(m.Groups["coef"].Value);
            char variableSymbol = m.Groups["variable"].Value.ToCharArray()[0];
            int power = int.Parse(m.Groups["power"].Value);

            Coef = coef;
            VariableSymbol = variableSymbol;
            Power = power;
        }
        public Term(Match m)
        {
            FromMatch(m);
        }
        public void FromMatch(Match m)
        {
            int coef = int.Parse(m.Groups["coef"].Value);
            char variableSymbol = m.Groups["variable"].Value.ToCharArray()[0];
            int power = int.Parse(m.Groups["power"].Value);

            Coef = coef;
            VariableSymbol = variableSymbol;
            Power = power;
        }
        public override string ToString()
        {
            return string.Format("{0}{1}^{2}", Coef, VariableSymbol, Power);
        }
        public int Sign()
        {
            if(Coef > 0)
            {
                return 1;
            }
            else if (Coef < 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
