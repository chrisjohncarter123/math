using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Represents any type of equation in the form f=g
/// Provides properties for easy access to the equation in different ways
/// Does not handle solving the equation. That is done in classes that inherit from Solver
/// </summary>
namespace ConsoleApp3
{
    public abstract class Equation
    {

        public string AsString { get; set; }

        public Equation(string value)
        {
            AsString = value;
        }

        

        public string GetEquationSide(EquationSide side)
        {
            string pattern;

            string result = "";

            /*
             * Use regex to find left and right sides of equals side
             * */
            if(side == EquationSide.Right)
            {

            }
            else
            {

            }

            

            return result;
        }

        public string AddToBothSides(Term term)
        {
            string left = GetEquationSide(EquationSide.Left);
            string right = GetEquationSide(EquationSide.Right);

            left += term.ToString();
            right += term.ToString();

            return string.Format("{0}={1}",left,right);
        }
        public void MultToBothSides(string term)
        {
            


        }
        public void DivToBothSides(string term)
        {

        }

    }

    
}
