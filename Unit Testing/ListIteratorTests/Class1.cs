using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Iterator;
using NUnit.Framework;

namespace ListIteratorTests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        //[TestCase(new object[]{"dsd", "dsds", "dsd"})]
        //[TestCase(new object[] { "dsd", "dsds" })]

        public void TestConstructor()
        {
            string[] strings = new string[] { "sds", "xcx" };
            ListIterator list = new ListIterator(strings);
            FieldInfo fieldValue = typeof(ListIterator)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(p => p.FieldType == typeof(List<string>));

            var value = ((List<string>)fieldValue.GetValue(list)).ToArray();
            Assert.That(value, Is.EquivalentTo(strings));
        }

        [Test]
        public void TestInvalidConstructor()
        {
            string[] str = new string[] { };
            Assert.That(() => new ListIterator(str), Throws.ArgumentException);

        }

        [Test]
        public void TestHasNext()
        {
            var list = new ListIterator();
            FieldInfo listInfo = typeof(ListIterator)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(p => p.FieldType == typeof(List<string>));

            listInfo.SetValue(list, new List<string> { "a", "b" });

            //FieldInfo indexInfo = typeof(ListIterator)
            //    .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            //    .First(p => p.FieldType == typeof(int));

            //int value = (int) indexInfo.GetValue(list);


            Assert.That(() => list.HasNext(), Is.EqualTo(true));
        }

        [Test]
        public void InvalidHasNext()
        {
            var list = new ListIterator();
            Assert.That(() => list.HasNext(), Is.EqualTo(false));
        }

        [Test]
        public void Move()
        {
            var list = new ListIterator();

            FieldInfo listInfo = typeof(ListIterator)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(p => p.FieldType == typeof(List<string>));

            listInfo.SetValue(list, new List<string> { "a", "b" });


            FieldInfo indexInfo = typeof(ListIterator)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(p => p.FieldType == typeof(int));



            Assert.That(() => list.Move(), Is.EqualTo(true));
           
            int value = (int)indexInfo.GetValue(list);
            Assert.That(value, Is.EqualTo(1));

        }

        [Test]
        public void TestMoveFalse()
        {
            var list = new ListIterator();
            Assert.That(() => list.Move(), Is.EqualTo(false));
        }

        [Test]
        public void TestPrint()
        {
            var list = new ListIterator();

            FieldInfo listInfo = typeof(ListIterator)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(p => p.FieldType == typeof(List<string>));

            var strings = new List<string> {"a", "b"};
            listInfo.SetValue(list, strings);
            Assert.That(() => list.Print(), Is.EqualTo(strings[0]));

        }

        [Test]
        public void TestPrintInvalid()
        {
            var list = new ListIterator();
           
            Assert.That(() => list.Print(), Throws.InvalidOperationException);

        }





    }
}
