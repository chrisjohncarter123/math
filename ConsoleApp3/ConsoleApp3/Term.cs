﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Math
{
    public class Term
    {
        public int Coef { get; set; }
        public char VariableSymbol { get; set; }
        public int Power { get; set; }
     //   public const string Pattern = @"[\+\-]?((?<coef>[0-9]+)((?<variable>[a-z]+))(\^((?<power>[0-9]))))";
        public const string Pattern = @"(?<coef>[+-]?\d+(?:\.\d+)?)?(?<variable>(?(coef)(([a-z]))?|[a-z]))(?:\^(?<power>\d+))?";
        public const int DefaultCoef = 1;
        public const char DefaultVariableSymbol = ' ';
        public const int DefaultPower = 0;
        public Term()
        {
            Coef = DefaultCoef;
            VariableSymbol = DefaultVariableSymbol;
            Power = DefaultPower;
        }
        public Term(int coef, char variableSymbol, int power)
        {
            Coef = coef;
            VariableSymbol = variableSymbol;
            Power = power;
        }
        public Term(int coef, int power)
        {
            Coef = coef;
            VariableSymbol = DefaultVariableSymbol;
            Power = power;
        }
        public Term(int coef)
        {
            Coef = coef;
            VariableSymbol = DefaultVariableSymbol;
            Power = DefaultPower;
        }
        public Term(string input)
        {
            FromMatch(GetMatch(input));
        }
        public Term(Match m)
        {
            FromMatch(m);
        }
        public static Match GetMatch(string input)
        {
            return Regex.Match(input, Pattern, RegexOptions.None);
        }
        public void FromMatch(Match m)
        {
            int coefResult;
            Console.WriteLine(m.Groups["coef"].Value);
            if(!int.TryParse(m.Groups["coef"].Value, out coefResult))
            {
                Console.WriteLine("Coef parse failed");
                coefResult = DefaultCoef;
            }
            Coef = coefResult;

            char varResult;
            bool tryParseVariable = char.TryParse(m.Groups["variable"].Value, out varResult);
            if (!tryParseVariable)
            {
                varResult = DefaultVariableSymbol;
            }

            VariableSymbol = varResult;

            int powerResult;
            bool tryParsePower = int.TryParse(m.Groups["power"].Value, out powerResult);
            if (!tryParsePower)
            {
                powerResult = DefaultPower;
            }

            if(!tryParsePower && tryParseVariable)
            {
                powerResult = 1;
            }
            Power = powerResult;
        }

        //Using ToString instead of ToStringSimplified might be better when doing math operations
        public override string ToString()
        {
            string coef = "", var = "", pow = "";
            coef = Coef.ToString();
            pow = "^" + Power.ToString();
            if (!VariableSymbol.Equals(DefaultVariableSymbol))
            {
                var = VariableSymbol.ToString();
            }
            return string.Format("{0}{1}{2}", coef, var, pow);
        }
        public string ToStringSimplified()
        {
            string result = "";
            if(Coef == 0)
            {
                return "0";
            }
            if(Coef != 1 && VariableSymbol != DefaultVariableSymbol && Power == 1) 
            {
                return string.Format("{0}{1}", Coef, VariableSymbol);
            }
            if(Coef != 1 && VariableSymbol != DefaultVariableSymbol && Power != 1)
            {
                return string.Format("{0}{1}^{2}", Coef, VariableSymbol, Power);
            }
            if (Coef == 1 && VariableSymbol != DefaultVariableSymbol && Power != 1)
            {
                return string.Format("{0}^{1}", VariableSymbol, Power);
            }
            if (Coef == 1 && VariableSymbol != DefaultVariableSymbol && Power == 1)
            {
                return string.Format("{0}", VariableSymbol);
            }
            if(Coef == 1 && VariableSymbol != DefaultVariableSymbol && Power == 1)
            {
                return string.Format("{0}^{1}", VariableSymbol, Power);
            }
            if(VariableSymbol == DefaultVariableSymbol)
            {
                return string.Format("{0}", Coef);
            }
            return result;
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
