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
        public void TestBinary()
        {
            var ast = _parser.ParseBinaryExpression("1 or b and b or 1");
        }

        [TestMethod]
        public void TestFunctionDef()
        {
            var ast = _parser.ParseFunctionStatement("nor a b -> x => { x = not(a or b); }");
        }

        [TestMethod]
        public void TestMethod1()
        {
            var ast = _parser.Parse("true or (b or c)");
        }

        private BevalParser _parser;
    }
}