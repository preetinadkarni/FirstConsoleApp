using FirstConsoleApp;
using NUnit.Framework;

namespace UnitTests
{
    public class StringCalculatorUnitTests
    {
        private StringCalculator _stringCalculator;
        
        [SetUp]
        public void Setup()
        {
           _stringCalculator = new StringCalculator();
        }

        [Test]
        public void GivenInputIsBlankWhenAddThenReturnsZero()
        {
            var input = "";
            Assert.AreEqual(_stringCalculator.Add(input),0);
        }
        
        [TestCase("1", ExpectedResult=1)]
        [TestCase("3", ExpectedResult=3)]
        public int GivenInputIsASingleNumberWhenAddThenReturnsThatNumber(string input)
        {
            return _stringCalculator.Add(input);
        }
    }
}