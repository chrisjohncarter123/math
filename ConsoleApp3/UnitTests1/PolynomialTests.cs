using Microsoft.VisualStudio.TestTools.UnitTesting;
using Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math.Tests
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
            Polynomial p = new Polynomial("2a^4+a^2=0");

            p.OrderTermsByPower(EquationSide.Left);

            Assert.AreEqual("2a^4+a^2=0", p.AsString);
        }


        [TestMethod()]
        public void OrderTermsByPowerTest2()
        {
            Polynomial p = new Polynomial("2a^4+a^2+a^7=0");

            p.OrderTermsByPower(EquationSide.Left);

            Assert.AreEqual("a^7+2a^4+a^2=0", p.AsString);
        }

        [TestMethod()]
        public void TermListToEquationTest()
        {
            List<Term> terms = new List<Term>();
            terms.Add(new Term(2, 'a', 4));
            terms.Add(new Term(1, 'a', 2));

            Equation result = Polynomial.TermListToEquation(terms);
            Equation expected = new Equation("2a^4+a^2=0");

            Assert.AreEqual(expected.AsString, result.AsString);

        }

        [TestMethod()]
        public void SolveLinearForXTest()
        {
            Polynomial p = new Polynomial("2x+1=0");

            double result = p.SolveLinearForX();

            Assert.AreEqual(-.5, result);
        }
        [TestMethod()]
        public void SolveLinearForXTest2()
        {
            Polynomial p = new Polynomial("10x+10=0");

            double result = p.SolveLinearForX();

            Assert.AreEqual(-1, result);
        }
        [TestMethod()]
        public void SolveLinearForXTest3()
        {
            Polynomial p = new Polynomial("2x=0");

            double result = p.SolveLinearForX();

            Assert.AreEqual(0, result);
        }

        [TestMethod()]
        public void AddTermsOfPowerTest()
        {
            Polynomial p = new Polynomial("2x^2+2x^2=0");

            Term result = p.AddTermsOfPower(EquationSide.Left, 'x', 2);

            Assert.AreEqual(4, result.Coef);
            Assert.AreEqual('x', result.VariableSymbol);
            Assert.AreEqual(2, result.Power);
        }

        [TestMethod()]
        public void AddTermsOfPowerTest2()
        {
            Polynomial p = new Polynomial("7x+x=0");

            Term result = p.AddTermsOfPower(EquationSide.Left, 'x', 1);

            Assert.AreEqual(8, result.Coef);
            Assert.AreEqual('x', result.VariableSymbol);
            Assert.AreEqual(1, result.Power);
        }

        [TestMethod()]
        public void AddTermsOfPowerTest3()
        {
            Polynomial p = new Polynomial("25+20=0");

            Term result = p.AddTermsOfPower(EquationSide.Left, Term.DefaultVariableSymbol, 0);

            Assert.AreEqual(45, result.Coef);
            Assert.AreEqual(Term.DefaultVariableSymbol, result.VariableSymbol);
            Assert.AreEqual(0, result.Power);
        }

        [TestMethod()]
        public void AddAllLikeTermsOnLeftSideTest()
        {
            Polynomial p = new Polynomial("2x^2+2x^2+7x+x=0");

            p.AddAllLikeTermsOnLeftSide();

            Assert.AreEqual("4x^2+8x=0",p.AsString);
        }

        [TestMethod()]
        public void ToSimpliestFormTest()
        {
            Polynomial p = new Polynomial("2x^2+12x=0");

            p.ToSimpliestForm();

            Assert.AreEqual("2x^2+12x=0", p.AsString);
        }

        [TestMethod()]
        public void ToSimpliestFormTest2()
        {
            Polynomial p = new Polynomial("12x-7=2x^2-87x^5");

            p.ToSimpliestForm();

            Assert.AreEqual("87x^5-2x^2+12x-7=0", p.AsString);
        }
        [TestMethod()]
        public void ToSimpliestFormTest3()
        {
            Polynomial p = new Polynomial("2x+2+4=0");

            p.ToSimpliestForm();

            Assert.AreEqual("2x+6=0", p.AsString);
        }
        [TestMethod()]
        public void ToSimpliestFormTest4()
        {
            Polynomial p = new Polynomial("2x+2-4=0");

            p.ToSimpliestForm();

            Assert.AreEqual("2x-2=0", p.AsString);
        }


        [TestMethod()]
        public void PolynomialTest()
        {
            List<Term> t = new List<Term>();
            t.Add(new Term("2x^2"));
            t.Add(new Term("x"));

            Polynomial p = new Polynomial(t);

            Assert.AreEqual("2x^2+x=0", p.AsString);
        }

        [TestMethod()]
        public void MoveAllTermsToLeftSideTest()
        {
            Polynomial poly = new Polynomial("2x+2+4=4x");

            poly.MoveAllTermsToLeftSide();

            Assert.AreEqual("2x+2+4-4x=4x-4x", poly.AsString);
        }

        [TestMethod()]
        public void MoveAllTermsToLeftSideTest2()
        {
            Polynomial poly = new Polynomial("2x+2+4=4x-3x+2x-5x^2+1");

            poly.MoveAllTermsToLeftSide();

            Assert.AreEqual("2x+2+4-4x+3x-2x+5x^2-1=4x-3x+2x-5x^2+1-4x+3x-2x+5x^2-1", poly.AsString);
        }

        [TestMethod()]
        public void MoveAllTermsToLeftSideTest3()
        {
            Polynomial poly = new Polynomial("2x+2+4=0");

            poly.MoveAllTermsToLeftSide();

            Assert.AreEqual("2x+2+4=0", poly.AsString);
        }
        [TestMethod()]
        public void MoveAllTermsToLeftSideTest4()
        {
            Polynomial poly = new Polynomial("0=0+5");

            poly.MoveAllTermsToLeftSide();

            Assert.AreEqual("-5=0+5-5", poly.AsString);
        }

        [TestMethod()]
        public void CompleteSolveTest()
        {
            Polynomial poly = new Polynomial("2x+2+4=4x-3x+2x+1+0+0");

            double result = poly.CompleteSolve();

            Assert.AreEqual(5, result);
        }
        [TestMethod()]
        public void CompleteSolveTest2()
        {
            Polynomial poly = new Polynomial("2x+2=0");

            double result = poly.CompleteSolve();

            Assert.AreEqual(-1, result);
        }
        [TestMethod()]
        public void CompleteSolveTest3()
        {
            Polynomial poly = new Polynomial("0=20x-10");

            double result = poly.CompleteSolve();

            Assert.AreEqual(.5d, result);
        }
    }
}