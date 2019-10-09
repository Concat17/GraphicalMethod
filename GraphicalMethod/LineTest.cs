using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GraphicalMethod
{
    [TestFixture]
    public class LineTest
    {
        [Test]
        public void SimplifyPositiveYTest1()
        {
            var x = 3;
            var y = 2;
            var k = 12;
            var isMore = false;
            Line line1 = new Line(x, y, k, isMore); 
            Assert.IsTrue(line1.A == -x && line1.B == y && line1.C == k && line1.isMore == isMore);
        }

        [Test]
        public void SimplifyNegativeYTest1()
        {
            var x = 2;
            var y = -1;
            var k = 1;
            var isMore = false;
            Line line1 = new Line(x, y, k, isMore); 
            Assert.IsTrue(line1.A == x && line1.B == -y && line1.C == -k && line1.isMore != isMore);
        }
    }
}
