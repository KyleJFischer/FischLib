using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class EnglishLanguageTest
    {
        [DataRow("Hello", 2)]
        [DataTestMethod]
        public void TestVowelCount(string word, int expectedResult)
        {
            var result = FischToolsLib.EnglishLanguage.GetVowelCount(word);
            Assert.AreEqual(expectedResult, result);
        }
        [DataRow("Hello", 3)]
        [DataTestMethod]
        public void TestConstantCount(string word, int expectedResult)
        {
            var result = FischToolsLib.EnglishLanguage.GetConstantCount(word);
            Assert.AreEqual(expectedResult, result);
        }
        [DataRow("Hello", true)]
        [DataTestMethod]
        public void DoesWordExist(string word, bool expectedResult)
        {
            var result = FischToolsLib.EnglishLanguage.DoesWordExist(word);
            Assert.AreEqual(expectedResult, result);
        }
    }

}
