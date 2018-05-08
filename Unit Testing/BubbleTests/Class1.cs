using System;
using System.Linq;
using System.Reflection;
using BubbleSort;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace BubbleTests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { int.MaxValue })]
        [TestCase(new int[] { int.MinValue })]
        [TestCase(new int[] { 0 })]
        [TestCase(new int[] { -12, -34, -34 })]
        public void TestConstructor(int[] nums)
        {
            var bubble = new Bubble(nums);
            var bubbleInfo = typeof(Bubble)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(p => p.FieldType == typeof(int[]));
            var value = (int[])bubbleInfo.GetValue(bubble);

            Assert.That(value, Is.EquivalentTo(nums));


        }

        [Test]
        [TestCase(new int[] { })]
        public void TestConstructorInvalid(int[] nums)
        {
            Assert.That(() => new Bubble(nums), Throws.ArgumentException);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 56, 89, -89, 45, 3, 78})]
        [TestCase(new int[] { int.MaxValue })]
        [TestCase(new int[] { int.MinValue })]
        [TestCase(new int[] { 0 })]
        [TestCase(new int[] { -12, -34, -34 })]
        public void TestSort(int[] nums)
        {
            var bubble = new Bubble(nums);
            var bubbleInfo = typeof(Bubble)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(p => p.FieldType == typeof(int[]));
            bubble.Sort();
            var value = (int[])bubbleInfo.GetValue(bubble);
            Array.Sort(nums);

            Assert.That(value, Is.EquivalentTo(nums));

        }

        [Test]
        [TestCase(new int[] { })]
        public void TestSortInvalid(int[] nums)
        {
            var bubble = new Bubble();
            var bubbleInfo = typeof(Bubble)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(p => p.FieldType == typeof(int[]));
            bubbleInfo.SetValue(bubble, nums);
            
           Assert.That(() => bubble.Sort(), Throws.InvalidOperationException);
        }

    }
}

