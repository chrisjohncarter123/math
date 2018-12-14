using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Math
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
            return terms.OrderByDescending(t => t.Power).ToList();
            
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

        public List<Term> GetTermsOfPower(List<Term> terms, int power)
        {
            List<Term> result = new List<Term>();

            foreach(Term t in terms)
            {
                if(t.Power == power)
                {
                    result.Add(t);
                }
            }

            return result;
        }

        public Term AddTermsOfPower(List<Term> terms, char var, int power)
        {
            int coef = 0;

            var query = from t in terms
                        where t.Power == power
                        where t.VariableSymbol == var
                        select t;
                        
            foreach(Term t in query)
            {
                coef += t.Coef;
            }

            Term result = new Term(coef, var, power);
            return result;
        }
        public void AddAllTermsOfPower(List<Term> terms)
        {

        }


        public double SolveLinearForX()
        {

            if(GetDegree() == 1)
            {
                
                List<Term> terms = Terms(EquationSide.Left);
                
                foreach (Term t in terms)
                {
                    Console.WriteLine(t);
                }
                terms = OrderTermsByPower(terms);
                Console.WriteLine("---------------------");
                foreach(Term t in terms)
                {
                    Console.WriteLine(t);
                }
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

                double top = System.Math.Sqrt((b * b) -(4* a * c));

                x1 = (-b + top) / (2 * a);
                x2 = (-b - top) / (2 * a);

                return x1;
            }
            else
            {
                return 0;
            }
        }


        public EquationSolutionInformation Solve()
        {
            EquationSolutionInformation sol = new EquationSolutionInformation();

            int degree = GetDegree();

            if(degree == 2)
            {
                SolveQuadForX();
            }
            else if(degree == 1)
            {
                SolveLinearForX();
            }

            return sol;
        }
    }

    
}
