using Microsoft.VisualStudio.TestTools.UnitTesting;
using Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Math.Tests
{
    [TestClass()]
    public class TermTests
    {
        [TestMethod()]
        public void TermTest()
        {
            Term t = new Term();

            Assert.AreEqual(t.Coef, Term.DefaultCoef, "Coef failed");
            Assert.AreEqual(t.VariableSymbol, Term.DefaultVariableSymbol, "VariableSymbol failed");
            Assert.AreEqual(t.Power, Term.DefaultPower, "Power failed");
        }

        [TestMethod()]
        public void TermTest1()
        {
            Term t = new Term(1, 'x', 2);

            Assert.AreEqual(t.Coef, 1, "Coef failed");
            Assert.AreEqual(t.VariableSymbol, 'x', "VariableSymbol failed");
            Assert.AreEqual(t.Power, 2, "Power failed");
        }

        [TestMethod()]
        public void TermTest2()
        {
            string input = "2x^3";

            Term t = new Term(input);

            Assert.AreEqual(t.Coef, 2, "Coef failed");
            Assert.AreEqual(t.VariableSymbol, 'x', "VariableSymbol failed");
            Assert.AreEqual(t.Power, 3, "Power failed");
        }

        [TestMethod()]
        public void TermTest3()
        {
            string input = "x";

            Term t = new Term(input);

            Assert.AreEqual(t.Coef, 1, "Coef failed");
            Assert.AreEqual(t.VariableSymbol, 'x', "VariableSymbol failed");
            Assert.AreEqual(t.Power, 1, "Power failed");
        }

        [TestMethod()]
        public void TermTest4()
        {
            string input = "4";

            Term t = new Term(input);

            Assert.AreEqual(t.Coef, 4, "Coef failed");
            Assert.AreEqual(t.VariableSymbol, Term.DefaultVariableSymbol, "VariableSymbol failed");
            Assert.AreEqual(t.Power, Term.DefaultPower, "Power failed");
        }

        [TestMethod()]
        public void TermTest5()
        {
            string input = "4^2";

            Term t = new Term(input);

            Assert.AreEqual(t.Coef, 4, "Coef failed");
            Assert.AreEqual(t.VariableSymbol, Term.DefaultVariableSymbol, "VariableSymbol failed");
            Assert.AreEqual(t.Power, 2, "Power failed");
        }

        [TestMethod()]
        public void TermTest6()
        {
            string input = "2x";

            Term t = new Term(input);

            Assert.AreEqual(t.Coef, 2, "Coef failed");
            Assert.AreEqual(t.VariableSymbol, 'x', "VariableSymbol failed");
            Assert.AreEqual(t.Power, 1, "Power failed");
        }

        [TestMethod()]
        public void TermTest7()
        {
            string input = "-4";

            Term t = new Term(input);

            Assert.AreEqual(t.Coef, -4, "Coef failed");
            Assert.AreEqual(t.VariableSymbol, Term.DefaultVariableSymbol, "VariableSymbol failed");
            Assert.AreEqual(t.Power, Term.DefaultPower, "Power failed");
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
        public void FromMatchTest2()
        {
            Match m = Regex.Match("2y^2", Term.Pattern);
            Term result = new Term();

            result.FromMatch(m);

            Assert.AreEqual(result.Coef, 2, "Coef failed");
            Assert.AreEqual(result.VariableSymbol, 'y', "VariableSymbol failed");
            Assert.AreEqual(result.Power, 2, "Power failed");
        }

        [TestMethod()]
        public void FromMatchTest3()
        {
            Match m = Regex.Match("2", Term.Pattern);
            Term result = new Term();

            result.FromMatch(m);

            Assert.AreEqual(result.Coef, 2, "Coef failed");
            Assert.AreEqual(result.VariableSymbol, Term.DefaultVariableSymbol, "VariableSymbol failed");
            Assert.AreEqual(result.Power, Term.DefaultPower, "Power failed");
        }
        [TestMethod()]
        public void FromMatchTest4()
        {
            Match m = Regex.Match("a", Term.Pattern);
            Term result = new Term();

            result.FromMatch(m);

            Assert.AreEqual(result.Coef, 1, "Coef failed");
            Assert.AreEqual(result.VariableSymbol, 'a', "VariableSymbol failed");
            Assert.AreEqual(result.Power, 1, "Power failed");
        }
        [TestMethod()]
        public void FromMatchTest5()
        {
            Match m = Regex.Match("a^2", Term.Pattern);
            Term result = new Term();

            result.FromMatch(m);

            Assert.AreEqual(result.Coef, 1, "Coef failed");
            Assert.AreEqual(result.VariableSymbol, 'a', "VariableSymbol failed");
            Assert.AreEqual(result.Power, 2, "Power failed");
        }
        [TestMethod()]
        public void FromMatchTest6()
        {
            Match m = Regex.Match("3^2", Term.Pattern);
            Term result = new Term();

            result.FromMatch(m);

            Assert.AreEqual(result.Coef, 3, "Coef failed");
            Assert.AreEqual(result.VariableSymbol, Term.DefaultVariableSymbol, "VariableSymbol failed");
            Assert.AreEqual(result.Power, 2, "Power failed");
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Term t = new Term(2, 'x', 3);

            string result = t.ToString();

            Assert.AreEqual("2x^3", result);
        }
        [TestMethod()]
        public void ToStringSimplifiedTest()
        {
            Term t = new Term(1, 'x', 3);

            string result = t.ToStringSimplified();

            Assert.AreEqual("x^3", result);
        }
        [TestMethod()]
        public void ToStringSimplifiedTest2()
        {
            Term t = new Term(0, 'x', 3);

            string result = t.ToStringSimplified();

            Assert.AreEqual("0", result);
        }
        [TestMethod()]
        public void ToStringSimplifiedTest3()
        {
            Term t = new Term(1, 'x', 1);

            string result = t.ToStringSimplified();

            Assert.AreEqual("x", result);
        }
        [TestMethod()]
        public void ToStringSimplifiedTest4()
        {
            Term t = new Term(1, 'x', 2);

            string result = t.ToStringSimplified();

            Assert.AreEqual("x^2", result);
        }
        [TestMethod()]
        public void ToStringSimplifiedTest5()
        {
            Term t = new Term(2, 'y', 2);

            string result = t.ToStringSimplified();

            Assert.AreEqual("2y^2", result);
        }
        [TestMethod()]
        public void ToStringSimplifiedTest6()
        {
            Term t = new Term(2, Term.DefaultVariableSymbol, Term.DefaultPower);

            string result = t.ToStringSimplified();

            Assert.AreEqual("2", result);
        }
        [TestMethod()]
        public void GetTermTest()
        {
            string input = "2x^3";

            Match term = Term.GetMatch(input);

            Assert.AreEqual("2", term.Groups["coef"].Value);
            Assert.AreEqual("x", term.Groups["variable"].Value);
            Assert.AreEqual("3", term.Groups["power"].Value);

        }

       
    }
}