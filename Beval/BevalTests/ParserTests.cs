using Beval;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BevalTests
{
    [TestClass]
    public class ParserTests
    {
        [TestInitialize]
        public void Setup()
        {
            _parser = new BevalParser();
        }

        [TestMethod]
        public void TestMethod1()
        {
        }

        private BevalParser _parser;
    }
}