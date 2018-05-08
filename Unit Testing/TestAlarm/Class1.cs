using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

using DataBase;
using Moq;

namespace TestAlarm
{
    [TestFixture]
    public class DataBaseTest
    {
        private DataBase.DataBase database;

        [Test]
        [TestCase((new int[] {1, 2, 3, 4}))]
        [TestCase(new int[] { })]
        public void TestValidConstructor(int[] values)
        {
            DataBase.DataBase db = new DataBase.DataBase(values);

            FieldInfo fieldValue = typeof(DataBase.DataBase)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(p => p.FieldType == typeof(int[]));

            int[] valueInClass = (int[]) (fieldValue.GetValue(db));

            Assert.That(valueInClass, Is.EquivalentTo(values.Concat(new int[valueInClass.Length - values.Length])));

        }

        [Test]
        public void TestInvalidConstructor()
        {
            int[] values = new int[17];
            Assert.That(() => new DataBase.DataBase(values), Throws.InvalidOperationException);

        }

        [Test]
        [TestCase(int.MaxValue)]
        [TestCase(0)]
        [TestCase(int.MinValue)]
        [TestCase(-2)]
        public void TestAddMethod(int value)
        {
            DataBase.DataBase db = new DataBase.DataBase();
            db.Add(value);
            FieldInfo fieldInfo = typeof(DataBase.DataBase).GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(p => p.FieldType == typeof(int[]));
            FieldInfo currentIndexInfo = typeof(DataBase.DataBase)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(p => p.FieldType == (typeof(int)));
            int firstValue = ((int[]) fieldInfo.GetValue(db)).First();
            int currentIndex = (int) currentIndexInfo.GetValue(db);
            Assert.That(firstValue, Is.EqualTo(value));
            Assert.That(currentIndex, Is.EqualTo(1));

        }

        [Test]
        public void TestAddMethod()
        {

            DataBase.DataBase db = new DataBase.DataBase();

            FieldInfo currentIndexInfo = typeof(DataBase.DataBase)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(p => p.FieldType == (typeof(int)));


            currentIndexInfo.SetValue(db, 16);
            Assert.That(() => db.Add(1), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(new int[]{ int.MaxValue})]
        [TestCase((new int[] { 1, 2, 3, 4 }))]
        [TestCase(new int[] { -23})]
        public void Remove(int[] values)
        {
            DataBase.DataBase db = new DataBase.DataBase();
            FieldInfo currentIndexInfo = typeof(DataBase.DataBase)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(p => p.FieldType == (typeof(int)));

            FieldInfo fieldValue = typeof(DataBase.DataBase)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(p => p.FieldType == typeof(int[]));

            fieldValue.SetValue(db, values);
            currentIndexInfo.SetValue(db, values.Length);
            
            db.Remove();
            int currentIndex = (int) currentIndexInfo.GetValue(db);
            Assert.That(currentIndex, Is.EqualTo(values.Length - 1));

        }
        [Test]
        public void TestInvalidRemove()
        {
            DataBase.DataBase db = new DataBase.DataBase();
            Assert.That(() => db.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(new int[] { int.MaxValue })]
        [TestCase((new int[] { 1, 2, 3, 4 }))]
        [TestCase(new int[] { -23 })]
        public void FetchMethod(int[] values)
        {
            DataBase.DataBase db = new DataBase.DataBase();
        
            FieldInfo fieldValue = typeof(DataBase.DataBase)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(p => p.FieldType == typeof(int[]));

            fieldValue.SetValue(db, values);
            FieldInfo currentIndexInfo = typeof(DataBase.DataBase)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(p => p.FieldType == (typeof(int)));
            currentIndexInfo.SetValue(db, values.Length);
            Assert.That(db.Fetch(), Is.EquivalentTo(values));

        }

        [Test]
        public void InvalidFetchMethod()
        {
            DataBase.DataBase db = new DataBase.DataBase();
            Assert.That(db.Fetch, Throws.InvalidOperationException);
        }


    }

}

