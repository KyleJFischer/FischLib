using FischToolsLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class CalculationsTest
    {
        [DataRow(2, 2)]
        [DataRow(3, 6)]
        [DataRow(4, 24)]
        [DataRow(5, 120)]
        [DataTestMethod]
        public void Factorial(int i, int expectedResult)
        {
            var result = Calculations.Factorial(i);
            Assert.AreEqual(expectedResult, result);
        }
        
    }

}
