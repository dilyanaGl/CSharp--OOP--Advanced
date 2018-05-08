using System;
using MatchClass;
using NUnit.Framework;

namespace MathTests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-12)]
        [TestCase(12.23)]
        [TestCase(double.MaxValue)]
        [TestCase(double.MinValue)]
        public void TestMathAbs(double value)
        {
            var math = new MathOperations(value);

            Assert.That(math.Abs, Is.EqualTo(Math.Abs(value)));


        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-12)]
        [TestCase(12.23)]
        [TestCase(double.MaxValue)]
        [TestCase(double.MinValue)]
        public void TestMathFloor(double value)
        {
            var math = new MathOperations(value);

            Assert.That(math.Floor, Is.EqualTo(Math.Floor(value)));


        }

    }
}
