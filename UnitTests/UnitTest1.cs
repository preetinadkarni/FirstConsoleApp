using FirstConsoleApp;
using NUnit.Framework;

namespace UnitTests
{
    public class Tests
    {
        private StringCalculator _sc;
        
        [SetUp]
        public void Setup()
        {
           _sc = new StringCalculator();
        }

        [Test]
        public void GivenInputIsBlankWhenAddThenReturnsZero()
        {
            _sc.input = "";
            Assert.AreEqual(_sc.Add(_sc.input),0);
        }
    }
}