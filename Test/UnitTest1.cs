using NUnit.Framework;
using ServiceClient1;
namespace Test
{
    [TestFixture]
    public class Tests
    {
        private Processor _processor;

        [SetUp]
        public void Setup()
        {
            _processor = new Processor();
        }

        [Test]
        public void Test1()
        {
            
            Assert.Pass();
        }
    }
}