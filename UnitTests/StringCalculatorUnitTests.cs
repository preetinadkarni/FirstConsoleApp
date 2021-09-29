using System;
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
        
        [TestCase("1,2", ExpectedResult=3)]
        [TestCase("3,5", ExpectedResult=8)]
        [TestCase("1,2,3", ExpectedResult=6)]
        [TestCase("3,5,3,9", ExpectedResult=20)]
        public int GivenInputHasCommaSeparatedNumbersWhenAddThenReturnsSumOfNumbers(string input)
        {
            return _stringCalculator.Add(input);
        }
        
        [TestCase("1,2\n3", ExpectedResult=6)]
        [TestCase("3\n5\n3,9", ExpectedResult=20)]
        public int GivenInputHasLineBreaksOrCommasSeparatedNumbersWhenAddThenReturnsSumOfNumbers(string input)
        {
            return _stringCalculator.Add(input);
        }
        
        [Test]
        public void GivenInputHasNegativeNumberWhenAddThenReturnsAnException()
        {
            Exception ex = Assert.Throws<System.ArgumentException>(delegate() { _stringCalculator.Add("-1,2,-3");});
            Assert.AreEqual(ex.Message,"Negatives not allowed: -1, -3");
        }
    }
}