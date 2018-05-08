using System;
using CustomLinkedList;
using NUnit.Framework;

namespace ListTests
{
    [TestFixture]
    public class Class1
    {
        private DynamicList<int> list;
       
        [Test]
        public void TestConstructorCount()
        {
            list= new DynamicList<int>();
            Assert.That(list.Count, Is.EqualTo(0));

        }

       

        [Test]
        public void TestAddCommand()
        {
            list = new DynamicList<int>();
            list.Add(1);
            Assert.That(list[0], Is.EqualTo(1));
        }

        [Test]
        public void TestCountCommand()
        {
            list = new DynamicList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.AreEqual(list.Count, 3);
        }

        [Test]
        public void TestRemoveCommand()
        {
            list = new DynamicList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Remove(3);
            Assert.AreEqual(list.Count, 2);
        }

        [Test]
        public void TestRemoveAtCommand()
        {
            list = new DynamicList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.AreEqual(list.RemoveAt(0), 1);
        }

        [Test]
        public void TestInvelidIndex()
        {
            list = new DynamicList<int>();
            Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(10));
           
        }


        [Test]
        public void TestIndexOf()
        {
            list = new DynamicList<int>();
            list.Add(1);
            list.Add(2);
            Assert.AreEqual(list.IndexOf(1), 0);
        }

        [Test]
        public void TestContainsMethod()
        {
            list = new DynamicList<int>();
            list.Add(2);
            list.Add(3);
            Assert.AreEqual(list.Contains(3), true);
        }
    }
}
