using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestExample
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddTest()
        {
            FirstProgram.Calculator calculator = new FirstProgram.Calculator();
            int resultAdd = 4 + 5;
            Assert.AreEqual(resultAdd, calculator.add(4, 5));
        }

        [TestMethod]
        public void SubTest()
        {
            FirstProgram.Calculator calculator = new FirstProgram.Calculator();
            int resultSub = 6 - 4;
            Assert.AreEqual(resultSub, calculator.sub(6, 4));
        }

        [TestMethod]
        public void exceptionTest()
        {
            Assert.ThrowsException<System.Exception>(() => new FirstProgram.Calculator().exc(true));
        }
    }
}