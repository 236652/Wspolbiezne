using NUnit.Framework;

namespace FirstProgram.nUnitTest
{
    public class Tests
    {
        private const bool X = true;

        [Test]
        public void Test1()
        {
            Calculator calculator = new Calculator();
            int resultAdd = 4 + 5;
            int resultSub = 6 - 4;
            Assert.AreEqual(resultAdd, calculator.add(4,5));
            Assert.AreEqual(resultSub, calculator.sub(6, 4));
            Assert.Throws<System.Exception>(() => new Calculator().exc(true));
        }
    }
}