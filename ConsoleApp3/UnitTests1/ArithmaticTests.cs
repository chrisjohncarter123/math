using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp3;

namespace UnitTests1
{
    [TestClass]
    public class ArithmaticTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Arithmatic solver = new Arithmatic();

            string result = solver.Solve("(1+1)");

            Assert.AreEqual(result, "2");
           
        }

        [TestMethod]
        public void TestMethod2()
        {
            Arithmatic solver = new Arithmatic();

            string result = solver.Solve("(1+2)");

            Assert.AreEqual(result, "3");

        }

        [TestMethod]
        public void TestMethod3()
        {
            Arithmatic solver = new Arithmatic();

            string result = solver.Solve("(2*2)");

            Assert.AreEqual(result, "4");

        }

        [TestMethod]
        public void TestMethod4()
        {
            Arithmatic solver = new Arithmatic();

            string result = solver.Solve("((2*2)+1)");

            Assert.AreEqual(result, "5");

        }

        [TestMethod]
        public void TestMethod5()
        {
            Arithmatic solver = new Arithmatic();

            string result = solver.Solve("((1+1)+((1+1)+(1+1)))");

            Assert.AreEqual(result, "6");

        }

        [TestMethod]
        public void TestMethod6()
        {
            Arithmatic solver = new Arithmatic();

            string result = solver.Solve("(3+2*(1+1))");

            Assert.AreEqual(result, "7");

            Assert.AreEqual(solver.Solve("(1+1)"), "2");

        }

        [TestMethod]
        public void TestMethod7()
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

    }
}
