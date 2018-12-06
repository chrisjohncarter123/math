using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {

            Solver solver = new Solver();
            string[] strsAdd = {
                "(1+1)",
                "(1+1+1)",
                "(1+1)",
                "(1+(1+1))",
                "((1+1)+(1+1))",
                "((1+1)+(1+1))",
                "((1+1)+((1+1)+(1+1)))"
            };

            string[] strsMult = {
                "(2*2)",
                "(2*2*3)",
                "(2*(2*3))",
                "((2*2)*(2*2)*3)",
                "(1+3*2)",
                "(3*2+2)",
                "(3+2*(1+1))"
            };

            string[] strsPow = {
                "(2^2)",
                "(2^2^3)",
                "(2^(2^3))",
                "((2^2)^(2^2)^3)",
                "(1+3^2)",
                "(3*2^2)",
                "(3+2^(1+1))"
            };

            string[] strsCombine =
            {
                "(2+1*2)",
                "(1+2^3+1*2+1)",
                "(1+10*2^2)"

            };

            foreach (string s in strsCombine)
            {
                
                solver.Solve(s);
            }

            Console.ReadKey();
        }
    }
}
