using FirstConsoleApp;
using NUnit.Framework;

namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            var sc = new StringCalculator();
        }

        [Test]
        public void Test1()
        {
            sc.input = "";
            Assert.Equals(sc.Add(input),0);
        }
    }
}