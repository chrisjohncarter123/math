using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
/// <summary>
/// Represents any type of equation in the form f=g
/// Provides properties for easy access to the equation in different ways
/// Does not handle solving the equation. That is done in classes that inherit from Solver
/// </summary>
namespace Math
{
    public class Equation
    {

        public string AsString { get; set; }

        public Equation()
        {

        }
        public Equation(string value) 
        {
            

            AsString = value;
        }

        
        public void RemoveExtraZeros()
        {
            string pattern = @"[\+\-]0";
            
            AsString = Regex.Replace(AsString, pattern, "");

        }
        public void RemoveExtraZeroValuedCoefTerms()
        {
            string left = GetEquationSide(EquationSide.Left);
            string right = GetEquationSide(EquationSide.Right);
            string pattern = @"(?<coef>[+-]?0(?:\.0)?)?(?<variable>(?(coef)(([a-z]))?|[a-z]))(?:\^(?<power>\d+))?";

            if (left != "0")
            {
                left = Regex.Replace(left, pattern, "");
            }
            if (right != "0")
            {
                right = Regex.Replace(right, pattern, "");
            }


            AsString = string.Format("{0}={1}", left, right);

            
            
        }
        public void TrimLeadingPlusSignOnBothSides()
        {
            string left = GetEquationSide(EquationSide.Left);
            string right = GetEquationSide(EquationSide.Right);

            if (left.ToArray()[0].Equals('+'))
            {
                Console.WriteLine("Left");
                left = left.Remove(0, 1);
            }
            if (right.ToArray()[0].Equals('+'))
            {
                right = right.Remove(0, 1);
            }
            AsString = string.Format("{0}={1}", left, right);
        }
        public string GetEquationSide(EquationSide side)
        {
            string pattern = @"(?<left>.+)=(?<right>.+)";

            Match m = Regex.Match(AsString, pattern);

            if(side == EquationSide.Left)
            {
                return m.Groups["left"].Value;
            }
            else
            {
                return m.Groups["right"].Value;
            }

        }
        public void AddTermToOneSide(EquationSide side, Term term)
        {
            string sideStr = GetEquationSide(side);

            string result = sideStr;

            if (sideStr != "0")
            {
                if(term.Coef < 0)
                {
                    //result += "-";
                }
                else
                {
                    result += "+";
                }
               
            }
            else
            {
                result = "";
            }

            result += term.ToStringSimplified();


            string left, right;
            if(side == EquationSide.Left)
            {
                left = result;
                right = GetEquationSide(EquationSide.Right);
            }
            else
            {
                left = GetEquationSide(EquationSide.Left);
                right = result;
            }

            AsString = string.Format("{0}={1}", left, right);
        }
        public void AddTermToBothSides(Term term)
        {
            AddTermToOneSide(EquationSide.Left, term);
            AddTermToOneSide(EquationSide.Right, term);

            /*
            string left = GetEquationSide(EquationSide.Left);
            string right = GetEquationSide(EquationSide.Right);

            string leftResult = left;
            string rightResult = right;

            if(left != "0")
            {
                leftResult += "+";
            }
            else
            {
                leftResult = "";
            }
            if(right != "0")
            {
                rightResult += "+";
            }
            else
            {
                rightResult = "";
            }

            leftResult += term.ToString();
            rightResult += term.ToString();
            

            AsString = string.Format("{0}={1}",leftResult,rightResult);
            */
        }
        public void MultTermToBothSidesWithPars(Term term)
        {
            AsString = string.Format("({0})*({2})=({1})*({2})",
               GetEquationSide(EquationSide.Left),
               GetEquationSide(EquationSide.Right),
               term.ToString());


        }
        public void DivTermToBothSidesWithPars(Term term)
        {
            AsString = string.Format("({0})/({2})=({1})/({2})",
                GetEquationSide(EquationSide.Left),
                GetEquationSide(EquationSide.Right),
                term.ToString());
        }

        public void RemoveExtraParsAroundTerms()
        {
            string pattern = string.Format(@"\((?<inner>{0})\)", Term.Pattern); 
             //string.Format(@"\((?<inner>[+-]?(?<coef>\d+(?:\.\d+)?)?(?<variable>(?(coef)(([a-z]))?|[a-z]))(?:\^(?<power>\d+))?)\)", Term.Pattern);

            MatchCollection matches = Regex.Matches(AsString, pattern);
            
            while (Regex.IsMatch(AsString, pattern))
            {
                AsString = Regex.Replace(AsString, pattern, (m) => {

                    return m.Groups["inner"].Value;
                });
            }
        }

        public List<Term> Terms(EquationSide side)
        {
            string pattern = Term.Pattern;

            string equation = GetEquationSide(side);

            MatchCollection matches = Regex.Matches(equation, pattern, RegexOptions.None);

            List<Term> terms = new List<Term>();

            foreach (Match m in matches)
            {
                terms.Add(new Term(m));
            }

            return terms;
        }


    }

    
}
