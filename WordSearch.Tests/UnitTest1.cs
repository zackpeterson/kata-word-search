using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordSearch;

namespace WordSearch.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private readonly Program _program;

        public UnitTest1()
        {
            _program = new Program();
        }

        [TestMethod]
        public void TestMethod1()
        {
            var result = _program.Sample();
            Assert.IsTrue(result, "result should be true");
        }
    }
}