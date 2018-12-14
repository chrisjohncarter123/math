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
    public class EquationTests
    {
        [TestMethod()]
        public void EquationTest()
        {
            Equation e = new Equation("2x^2=21");

            Assert.AreEqual("2x^2=21", e.AsString);
        }

        [TestMethod()]
        public void GetEquationSideTestLeft()
        {
            Equation e = new Equation("2x+2=4x^2");

            string result = e.GetEquationSide(EquationSide.Left);

            Assert.AreEqual("2x+2", result);
        }
        [TestMethod()]
        public void GetEquationSideTestRight()
        {
            Equation e = new Equation("2x+2=4x^2");

            string result = e.GetEquationSide(EquationSide.Right);

            Assert.AreEqual("4x^2", result);
        }

        [TestMethod()]
        public void AddTermToOneSideTest()
        {
            Equation e = new Equation("2x=1");
            Term t = new Term("2y^2");

            e.AddTermToOneSide(EquationSide.Left, t);

            Assert.AreEqual("2x+2y^2=1", e.AsString);
        }

        [TestMethod()]
        public void AddTermToOneSideTest2()
        {
            Equation e = new Equation("2x=1");
            Term t = new Term("2y^2");

            e.AddTermToOneSide(EquationSide.Right, t);

            Assert.AreEqual("2x=1+2y^2", e.AsString);
        }


        [TestMethod()]
        public void AddToBothSidesTest()
        {
            Equation e = new Equation("2x=1");
            Term t = new Term("2y^2");

            e.AddTermToBothSides(t);

            Assert.AreEqual("2x+2y^2=1+2y^2", e.AsString);

        }

        [TestMethod()]
        public void AddToBothSidesTest2()
        {
            Equation e = new Equation("x=0");
            Term t = new Term("2y^2");

            e.AddTermToBothSides(t);

            Assert.AreEqual("x+2y^2=2y^2", e.AsString);

        }

        [TestMethod()]
        public void MultToBothSidesWithParsTest()
        {
            Equation e = new Equation("x=2");
            Term add = new Term("3y^2");

            e.MultTermToBothSidesWithPars(add);

            Assert.AreEqual("(x)*(3y^2)=(2)*(3y^2)", e.AsString);

        }

        [TestMethod()]
        public void DivToBothSidesWithParsTest()
        {
            Equation e = new Equation("x=2");
            Term add = new Term("3y^2");

            e.DivTermToBothSidesWithPars(add);

            Assert.AreEqual("(x)/(3y^2)=(2)/(3y^2)", e.AsString); ;
        }

        [TestMethod()]
        public void RemoveExtraParsAroundTermsTest()
        {
            Equation e = new Equation("(2x)+1=0");

            e.RemoveExtraParsAroundTerms();

            Assert.AreEqual("2x+1=0", e.AsString);


        }
        [TestMethod()]
        public void RemoveExtraParsAroundTermsTest2()
        {
            Equation e = new Equation("((2x))+1=(0)");

            e.RemoveExtraParsAroundTerms();

            Assert.AreEqual("2x+1=0", e.AsString);


        }
        [TestMethod()]
        public void RemoveExtraParsAroundTermsTest3()
        {
            Equation e = new Equation("(((((2x)))))+(((1)))=(0)");

            e.RemoveExtraParsAroundTerms();

            Assert.AreEqual("2x+1=0", e.AsString);


        }
        [TestMethod()]
        public void TermsTest()
        {
            Polynomial poly = new Polynomial("2x^3+1=0");

            List<Term> terms = poly.Terms(EquationSide.Left);

            Assert.AreEqual(2, terms.Count, "Count failed");
            Assert.AreEqual(2, terms[0].Coef, "Coef of 2x^2 failed");
            Assert.AreEqual('x', terms[0].VariableSymbol, "Variable Symbol of 2x^2 failed");
            Assert.AreEqual(3, terms[0].Power, "Power of 2x^2 failed");
            Assert.AreEqual(1, terms[1].Coef, "Coef of 1 failed");
        }

        
    }
}