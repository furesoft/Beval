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
        public void TestFunctionDef()
        {
            var ast = _parser.ParseFunctionStatement("nor a b = (a or b)");
        }

        [TestMethod]
        public void TestMethod1()
        {
            var ast = _parser.Parse("a or (b or c)");
        }

        private BevalParser _parser;
    }
}