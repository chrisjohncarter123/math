using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApp3.Tests
{
    [TestClass()]
    public class TermTests
    {
        [TestMethod()]
        public void TermTest()
        {
            string input = "2x^3";

            Term t = new Term(input);

            Assert.AreEqual(t.Coef, 2, "Coef failed");
            Assert.AreEqual(t.VariableSymbol, 'x', "VariableSymbol failed");
            Assert.AreEqual(t.Power, 3, "Power failed");
        }

        [TestMethod()]
        public void TermTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TermTest2()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TermTest3()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FromMatchTest()
        {
            Match m = Regex.Match("2x^3", Term.Pattern);
            Term result = new Term();

            result.FromMatch(m);

            Assert.AreEqual(result.Coef, 2, "Coef failed");
            Assert.AreEqual(result.VariableSymbol, 'x', "VariableSymbol failed");
            Assert.AreEqual(result.Power, 3, "Power failed");
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Term t = new Term(2, 'x', 3);

            string result = t.ToString();

            Assert.AreEqual("2x^3", result);
        }
    }
}