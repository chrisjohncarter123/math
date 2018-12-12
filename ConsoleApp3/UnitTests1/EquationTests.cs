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
            Assert.Fail();
        }

        [TestMethod()]
        public void GetEquationSideTest()
        {
            Equation e = new Equation("2x+2=4x^2");

            string result = e.GetEquationSide(EquationSide.Left);

            Assert.AreEqual("2x+2", result);
        }
        [TestMethod()]
        public void GetEquationSideTest2()
        {
            Equation e = new Equation("2x+2=4x^2");

            string result = e.GetEquationSide(EquationSide.Right);

            Assert.AreEqual("4x^2", result);
        }

        [TestMethod()]
        public void AddToBothSidesTest()
        {
            Equation e = new Equation("2x=1");
            Term t = new Term(2, 'y', 2);

            e.AddToBothSides(t);

            Assert.AreEqual("2x+2y^2=1+2y^2", e.AsString);
            
        }

        [TestMethod()]
        public void MultToBothSidesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DivToBothSidesTest()
        {
            Assert.Fail();
        }
    }
}