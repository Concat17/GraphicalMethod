using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalMethod
{
    [TestFixture]
    class PointManipulatorTest
    {
        [Test]
        public void LandingCheckTest1()
        {
            var line11 = new Line(3, 2, 12, false);
            var point = new PointF(1, 1);
            var island = PointManipulator.isLand(line11, point);
            Assert.IsTrue(island);
        }

        [Test]
        public void LandingCheckTest2()
        {
            var line11 = new Line(3, 2, 12, false);
            var point = new PointF(3, 2);
            var island = PointManipulator.isLand(line11, point);
            Assert.IsTrue(!island);
        }

        [Test]
        public void LandingCheckTest3()
        {
            var line11 = new Line(2, -1, 1, false);
            var point = new PointF(2, -1);
            var island = PointManipulator.isLand(line11, point);
            Assert.IsTrue(!island);
        }

        [Test]
        public void LandingCheckTest4()
        {
            var line11 = new Line(2, -1, 1, false);
            var point = new PointF(0, 0);
            var island = PointManipulator.isLand(line11, point);
            Assert.IsTrue(island);
        }

        [Test]
        public void LandingCheckTest5()
        {
            var line11 = new Line(3, 2, 12, false);
            var point = new PointF(1.2f, 1.4f);
            var island = PointManipulator.isLand(line11, point);
            Assert.IsTrue(island);
        }

        [Test]
        public void LandingCheckTest6()
        {
            var line11 = new Line(1, 2, 4, true);
            var point = new PointF(1.2f, 1.4f);
            var island = PointManipulator.isLand(line11, point);
            Assert.IsTrue(island);
        }

        [Test]
        public void LandingCheckTest7()
        {
            var line11 = new Line(2, -1, 1, false);
            var point = new PointF(1.2f, 1.4f);
            var island = PointManipulator.isLand(line11, point);
            Assert.IsTrue(island);
        }
    }
}
