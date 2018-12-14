using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Tests
{
    [TestClass()]
    public class PolynomialTests
    {
        [TestMethod()]
        public void IsInStandardLinearFormTest()
        {
            string input = "2x+1=0";
            Polynomial polynomial = new Polynomial(input);

            bool result = polynomial.IsInStandardLinearForm();

            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void IsInStandardLinearFormTest2()
        {
            string input = "x^3=1";
            Polynomial polynomial = new Polynomial(input);

            bool result = polynomial.IsInStandardLinearForm();

            Assert.AreEqual(false, result);
        }

        [TestMethod()]
        public void IsInStandardQuadFormTest()
        {
            string input = "x^2+2x=0";
            Polynomial polynomial = new Polynomial(input);

            bool result = polynomial.IsInStandardQuadForm();

            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void IsInStandardQuadFormTest2()
        {
            string input = "x^3=1";
            Polynomial polynomial = new Polynomial(input);

            bool result = polynomial.IsInStandardQuadForm();

            Assert.AreEqual(false, result);
        }

        [TestMethod()]
        public void GetDegreeTest()
        {
            string input = "3x^3+2x+1=0";
            Polynomial poly = new Polynomial(input);

            int result = poly.GetDegree();

            Assert.AreEqual(3, result);
        }

        [TestMethod()]
        public void GetDegreeTest2()
        {
            string input = "x^7+2x^9=0";
            Polynomial poly = new Polynomial(input);

            int result = poly.GetDegree();

            Assert.AreEqual(9, result);
        }

        [TestMethod()]
        public void OrderTermsByPowerTest()
        {
            List<Term> terms = new List<Term>();
            terms.Add(new Term(2, 'a', 4));
            terms.Add(new Term(1, 'a', 2));
            terms.Add(new Term(3, 2));

            List<Term> result = Polynomial.OrderTermsByPower(terms);

            Assert.AreEqual(3, result.Count, "Failed Count");
            Assert.AreEqual(4, result[0].Power, "Failed First Term");
            Assert.AreEqual(2, result[1].Power, "Failed Seccond Term");
            Assert.AreEqual(2, result[2].Power, "Failed Third Term");
        }

        [TestMethod()]
        public void TermListToEquationTest()
        {
            List<Term> terms = new List<Term>();
            terms.Add(new Term(2, 'a', 4));
            terms.Add(new Term(1, 'a', 2));
            terms.Add(new Term(3, 2));

            Equation result = Polynomial.TermListToEquation(terms);
            Equation expected = new Equation("2a^4+1a^2+3^2=0");

            Assert.AreEqual(expected.AsString, result.AsString);

        }

        [TestMethod()]
        public void SolveLinearForXTest()
        {
            Polynomial p = new Polynomial("2x+1=0");

            double result = p.SolveLinearForX();

            Assert.AreEqual(-.5, result);
        }
    }
}