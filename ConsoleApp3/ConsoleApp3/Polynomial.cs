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
        public Polynomial(List<Term> left) : base()
        {
            AsString = "0=0";
            foreach(Term t in left)
            {
                AddTermToOneSide(EquationSide.Left, t);
            }
            
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
        /*
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
        */
        public Term AddTermsOfPower(EquationSide side, char var, int power)
        {
            int coef = 0;

            List<Term> terms = Terms(side);

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
        
        public List<Term> AddAllLikeTerms(EquationSide side)
        {
            List<Term> result = new List<Term>();
            List<Term> terms = Terms(side);
            Dictionary<TermType, int> termCoefs = new Dictionary<TermType, int>();

            foreach (Term t in terms)
            {
                int value;
                TermType type = new TermType(t.Power, t.VariableSymbol);
                if(termCoefs.TryGetValue(type, out value))
                {
                    termCoefs[type] += t.Coef;
                }
                else
                {
                    termCoefs.Add(type, t.Coef);
                }
            }

            for(int i = 0; i < termCoefs.Count; i++)
            {
                TermType type = termCoefs.Keys.ToList()[i];
                int coef = termCoefs[type];

                result.Add(new Term(coef, type.VariableSymbol, type.Power));
            }

            return result;
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

        
        public Equation Simplify()
        {
            string left = GetEquationSide(EquationSide.Left);
            string right = GetEquationSide(EquationSide.Right);

            List<Term> rightTerms = Terms(EquationSide.Right);

            foreach(Term t in rightTerms)
            {
                Term minusT = new Term(-t.Coef, t.VariableSymbol, t.Power);
                AddTermToBothSides(t);
            }

            List<Term> leftTerms = AddAllLikeTerms(EquationSide.Left);
            leftTerms = OrderTermsByPower(leftTerms);

            Polynomial e = new Polynomial(leftTerms);

            return new Equation(e.AsString);
        }
        
    }
    struct TermType
    {
        public int Power { get; set; }
        public char VariableSymbol { get; set; }
        public TermType(int power, char var)
        {
            Power = power;
            VariableSymbol = var;
        }
    }
    
}
