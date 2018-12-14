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

        public static List<Term> OrderTermsByPower(List<Term> terms)
        {
            terms.OrderByDescending(t => t.Power);
            return terms;
        }
        public static Equation TermListToEquation(List<Term> terms)
        {
            Equation e = new Equation("0=0");
            foreach(Term t in terms)
            {
                e.AddTermToOneSide(EquationSide.Left, t);
            }
            return e;
        }
       
        /*
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
        */
        public double SolveLinearForX()
        {

            if(GetDegree() == 1)
            {
                List<Term> terms = Terms(EquationSide.Left);
                terms = OrderTermsByPower(terms);

                //ax+b=0
                //x=-b/a
                double a, b, x;
                a = terms[0].Coef;
                b = terms[1].Coef;
                x = (-b) / a;
                return x;
            }
            else
            {
                return 0;
            }  
        }
        public double SolveQuadForX()
        {
            if (GetDegree() == 2)
            {
                List<Term> terms = Terms(EquationSide.Left);
                terms = OrderTermsByPower(terms);

                //ax^2+bx+c=0
                //x=(b+-(sqrt(b^2-4*a*c))/(2*a)
                double a, b, c, x1, x2;
                a = terms[0].Coef;
                b = terms[1].Coef;
                c = terms[2].Coef;

                double inner = (b * b) - (4 * a * c);
                if(inner < 0)
                {
                    inner = 0;
                }

                double top = Math.Sqrt((b*b)-(4*a*c));

                x1 = (-b + top) / (2 * a);
                x2 = (-b - top) / (2 * a);

                return x1;
            }
            else
            {
                return 0;
            }
        }
    }

    
}
