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

        public void OrderTermsByPower(EquationSide side)
        {
            AsString = TermListToEquation(Terms(side).OrderByDescending(t => t.Power).ToList()).AsString;
            
        }
        public static Equation TermListToEquation(List<Term> leftSideTerms)
        {
            Equation e = new Equation("0=0");
            foreach(Term t in leftSideTerms)
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
        
        public void AddAllLikeTermsOnLeftSide()
        {
            List<Term> result = new List<Term>();
            List<Term> terms = Terms(EquationSide.Left);
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

            AsString = string.Format("{0}={1}", TermListToEquation(result).GetEquationSide(EquationSide.Left), GetEquationSide(EquationSide.Right));
        }
        

        public double SolveLinearForX()
        {
            //input expect to be either ax=0, or ax+b=0

            if(GetDegree() == 1)
            {
                
                List<Term> terms = Terms(EquationSide.Left);
                if(terms.Count == 1)
                {
                    return 0;
                }
                foreach (Term t in terms)
                {
                    Console.WriteLine(t);
                }
                OrderTermsByPower(EquationSide.Left);
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
                OrderTermsByPower(EquationSide.Left);

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

        public void MoveAllTermsToLeftSide()
        {
            List<Term> rightTerms = Terms(EquationSide.Right);

            foreach (Term t in rightTerms)
            {
                if (t.Coef != 0)
                {
                    Term minusT = new Term(-t.Coef, t.VariableSymbol, t.Power);
                    AddTermToBothSides(minusT);
                }
            }
           
        }
        public void ToSimpliestForm()
        {
            MoveAllTermsToLeftSide();
            AddAllLikeTermsOnLeftSide();
            OrderTermsByPower(EquationSide.Left);
            
        }
        public double CompleteSolve()
        {
            ToSimpliestForm();
            int degree = GetDegree();
            if(degree == 1)
            {
                return SolveLinearForX();
            }
            else if(degree == 2)
            {
                return SolveQuadForX();
            }
            return 0;
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
