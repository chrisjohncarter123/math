using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Math;

namespace UnitTests1
{
    [TestClass]
    public class ArithmaticTests
    {
        [TestMethod]
        public void ArithmaticTestsMethod1()
        {
            Arithmatic solver = new Arithmatic("(1+1)");

            string result = solver.Solve();

            Assert.AreEqual(result, "2");
           
        }

        [TestMethod]
        public void ArithmaticTestsMethod2()
        {
            Arithmatic solver = new Arithmatic("(1+2)");

            string result = solver.Solve();

            Assert.AreEqual(result, "3");

        }

        [TestMethod]
        public void ArithmaticTestsMethod3()
        {
            Arithmatic solver = new Arithmatic("(2*2)");

            string result = solver.Solve();

            Assert.AreEqual(result, "4");

        }

        [TestMethod]
        public void ArithmaticTestsMethod4()
        {
            Arithmatic solver = new Arithmatic("((2*2)+1)");

            string result = solver.Solve();

            Assert.AreEqual(result, "5");

        }

        [TestMethod]
        public void ArithmaticTestsMethod5()
        {
            Arithmatic solver = new Arithmatic("((1+1)+((1+1)+(1+1)))");

            string result = solver.Solve();

            Assert.AreEqual(result, "6");

        }

        [TestMethod]
        public void ArithmaticTestsMethod6()
        {
            Arithmatic solver = new Arithmatic("(3+2*(1+1))");

            string result = solver.Solve();

            Assert.AreEqual(result, "7");

        }

        /*
        [TestMethod]
        public void ArithmaticTestsMethod7()
        {
            Arithmatic solver = new Arithmatic();
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

            foreach (string s in strsAdd)
            {

                solver.Solve(s);
               
            }

        }
        */

    }
}
