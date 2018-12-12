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
        public void OrderByPowerTest()
        {
            Polynomial polynomial = new Polynomial("2x+5x^4+1x^2");

            string result = polynomial.OrderByPower();

            Assert.AreEqual("5x^4+1x^2+2x", result);
        }
    }
}