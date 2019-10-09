using NUnit.Framework;
using System;
using GraphicalMethod;

namespace GraphicalMethodTest
{
    [TestFixture]
    public class LineTest
    {
        [Test]
        public void SimplifyPositiveYTest()
        {
            var x = 3;
            var y = 2;
            var k = 12;
            var isMore = false;
            Line line1 = new Line(x, y, k, isMore);
            line1.Simplify();
            Assert.IsTrue(line1.A == -x && line1.B == y && line1.C == k && line1.isMore == isMore);
        }
    }
}
