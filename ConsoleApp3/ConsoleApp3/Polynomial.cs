using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Polynomial : Equation
    {

        public Polynomial(string input) : base(input)
        {
            
        }

        private List<Term> Terms(EquationSide side)
        {
            MatchCollection matches = TermMatchCollection(side);

            List<Term> terms = new List<Term>();

            foreach (Match m in matches)
            {
                terms.Add(new Term(m));
            }

            return terms;
        }
        private MatchCollection TermMatchCollection(EquationSide side)
        {
            string pattern = Term.Pattern;

            string equation = GetEquationSide(side);

            MatchCollection matches = Regex.Matches(equation, pattern, RegexOptions.None);

            return matches;
        }
        public bool IsInStandardLinearForm()
        {
            string pattern = @"^\d*x([+-]\d+)?=0$";
            return Regex.IsMatch(AsString, pattern);
        }

        public bool IsInStandardQuadForm()
        {
            string pattern = @"^\d*x\^2([+-]\d*x)?([+-]\d+)?=0$";
            return Regex.IsMatch(AsString, pattern);
        }

        public int GetDegree()
        {
            return Terms(EquationSide.Left).OrderByDescending(t => t.Power).First().Power;
        }

        /*
        public static string ConvertToStandardForm(string input)
        {
            string result;

            result = OrderByPower(input);
            result = AddTerms(result);

            return result;

        }
        */
        public string OrderByPower(string input)
        {
            string pattern = @"[\+\-]?((?<coef>[0-9]+)((?<variable>[a-z]+))(\^((?<power>[0-9]))))";

            RegexOptions options = RegexOptions.None;

            MatchCollection matches = Regex.Matches(input, pattern, options);

            IEnumerable<Match> query = matches.Cast<Match>().OrderByDescending(match =>
            {
                //check if power is 0 or 1, in shorthand notation

                int power = int.Parse(match.Groups["power"].Value);

                return power;

            });

            string output = "";

            foreach (Match m in query)
            {
                output += m.Value;
                Console.WriteLine(m);
            }

            return output;
        }

        public string AddTerms(string input)
        {
            //expecting input to be already in correct order

            string pattern = @"[\+\-]?((?<coef>[0-9]+)((?<variable>[a-z]+))(\^((?<power>[0-9]))))";

            RegexOptions options = RegexOptions.None;

            MatchCollection matches = Regex.Matches(input, pattern, options);

            string result = "";

            for (int i = int.Parse(matches[0].Groups["power"].Value); i >= 0; i--)
            {
                IEnumerable<Match> query =
                    from match in matches.Cast<Match>()
                    where int.Parse(match.Groups["power"].Value) == i
                    select match;

                int value = 0;

                foreach (Match m in query)
                {
                    value += int.Parse(m.Groups["coef"].Value);
                }

                if (value != 0)
                {
                    result += string.Format("{0}x^{1}", value, i);
                }

            }
            Console.WriteLine(result);
            return result;

        }
        public string SolveLinear(string input)
        {
            string pattern = @"^(?<coef>\d+)x[\+\-](?<const>\d+)$";
            Match m = Regex.Match(input, pattern);
            double varValue = (-double.Parse(m.Groups["const"].Value)) / double.Parse(m.Groups["coef"].Value);
            return varValue.ToString();
        }
        public string SolveQuad(string input)
        {
            return "";
        }
    }

    
}
