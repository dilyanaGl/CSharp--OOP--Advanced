using System;
using System.Linq;
using System.Reflection;
using DataBase___People;
using NUnit.Framework;
using NUnit.Framework.Internal;
using DataBasePeople;


namespace PeopleTests
{
    [TestFixture]
    public class Class1
    {

        [Test]
        public void TestConstructor()
        {
            Person[] people = new Person[] { new Person("Lola", 343434), new Person("John", 3434) };
            PeopleBase db = new PeopleBase();

            FieldInfo fieldValue = typeof(PeopleBase)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(p => p.FieldType == typeof(Person[]));

            fieldValue.SetValue(db, people);

            var value = (Person[])fieldValue.GetValue(db);
            var initialValue = people.Concat(new Person[value.Length - people.Length]);
            Assert.That(value, Is.EquivalentTo(initialValue));

        }

        [Test]
        public void InvalidTestConstructor()
        {
            Person[] longArray = new Person[17];

            Assert.That(() => new PeopleBase(longArray), Throws.InvalidOperationException);


        }

        [Test]
        public void TestAddMethod()
        {
            PeopleBase db = new PeopleBase();
            var value = new Person("A", 2);
            db.Add(value);
            FieldInfo fieldInfo = typeof(PeopleBase).GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(p => p.FieldType == typeof(Person[]));
            FieldInfo currentIndexInfo = typeof(PeopleBase)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(p => p.FieldType == (typeof(int)));
            Person firstValue = ((Person[])fieldInfo.GetValue(db)).First();
            int currentIndex = (int)currentIndexInfo.GetValue(db);

            Assert.That(firstValue, Is.EqualTo(value));
            Assert.That(currentIndex, Is.EqualTo(1));
        }

        [Test]
        public void TestInvalidAddMethod()
        {
            PeopleBase db = new PeopleBase();
            
            FieldInfo fieldValue = typeof(PeopleBase)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(p => p.FieldType == typeof(Person[]));

            FieldInfo currentIndexInfo = typeof(PeopleBase)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(p => p.FieldType == (typeof(int)));

            Person[] people = new Person[] { new Person("Lola", 343434), new Person("John", 3434) };

            fieldValue.SetValue(db, people);
            currentIndexInfo.SetValue(db, people.Length);

            Assert.That(() => db.Add(new Person("Lola", 12)), Throws.InvalidOperationException);
            Assert.That(() => db.Add(new Person("P", 3434)), Throws.InvalidOperationException);

        }

        [Test]
        public void InvalidAddIndex()
        {
            PeopleBase db = new PeopleBase();

            FieldInfo fieldValue = typeof(PeopleBase)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(p => p.FieldType == typeof(Person[]));

            FieldInfo currentIndexInfo = typeof(PeopleBase)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(p => p.FieldType == (typeof(int)));

            Person[] people = new Person[16];

            fieldValue.SetValue(db, people);
            currentIndexInfo.SetValue(db, people.Length);
            
            Assert.That(() => db.Add(new Person("1", 23)), Throws.InvalidOperationException);
        }

        [Test]
        public void Remove()
        {
            PeopleBase db = new PeopleBase();

            FieldInfo fieldValue = typeof(PeopleBase)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(p => p.FieldType == typeof(Person[]));

            FieldInfo currentIndexInfo = typeof(PeopleBase)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(p => p.FieldType == (typeof(int)));

            Person[] people = new Person[] { new Person("Lola", 343434), new Person("John", 3434) };

            fieldValue.SetValue(db, people);
            currentIndexInfo.SetValue(db, people.Length);
           
            var dbArray = (Person[]) fieldValue.GetValue(db);
            db.Remove();
            var otherArray = people.Take(people.Length - 1).Concat(new Person[dbArray.Length - people.Length + 1]).ToArray();
            int currentIndex = (int) currentIndexInfo.GetValue(db);
            Assert.That(currentIndex, Is.EqualTo(people.Length - 1));
            Assert.That(dbArray, Is.EquivalentTo(otherArray));
            
        }


        [Test]
        public void InvalidRemove()
        {
            PeopleBase db = new PeopleBase();
            Assert.That(() => db.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void TestFect()
        {
            PeopleBase db = new PeopleBase();

            FieldInfo fieldValue = typeof(PeopleBase)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(p => p.FieldType == typeof(Person[]));

            Person[] people = new Person[] { new Person("Lola", 343434), new Person("John", 3434) };

            fieldValue.SetValue(db, people);

            FieldInfo currentIndexInfo = typeof(PeopleBase)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(p => p.FieldType == (typeof(int)));

            currentIndexInfo.SetValue(db, people.Length);


            Assert.That(db.Fetch(), Is.EquivalentTo(people));
        }

        [Test]
        public void TestInvalidFetch()
        {
            PeopleBase db = new PeopleBase();
            Assert.That(() => db.Fetch(), Throws.InvalidOperationException);
        }

        [Test]
        public void TestFindById()
        {
            PeopleBase db = new PeopleBase();
            FieldInfo fieldValue = typeof(PeopleBase)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(p => p.FieldType == typeof(Person[]));

            Person[] people = new Person[] { new Person("Lola", 343434), new Person("John", 3434) };
            
            fieldValue.SetValue(db, people);

            FieldInfo currentIndexInfo = typeof(PeopleBase)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(p => p.FieldType == (typeof(int)));

            currentIndexInfo.SetValue(db, people.Length);

            Assert.That(() => db.FindById(343434).Name, Is.EqualTo("Lola"));
        }

        [Test]
        public void TestFindByIdInvalid()
        {
            PeopleBase db = new PeopleBase();

            FieldInfo fieldValue = typeof(PeopleBase)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(p => p.FieldType == typeof(Person[]));

            Person[] people = new Person[] { new Person("Lola", 343434), new Person("John", 3434) };

            fieldValue.SetValue(db, people);

            FieldInfo currentIndexInfo = typeof(PeopleBase)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(p => p.FieldType == (typeof(int)));

            currentIndexInfo.SetValue(db, people.Length);


            Assert.That(() => db.FindById(-2323), Throws.ArgumentException);
            Assert.That(() => db.FindById(334), Throws.InvalidOperationException);
        }

        [Test]
        public void TestFIndByName()
        {
            PeopleBase db = new PeopleBase();

            FieldInfo fieldValue = typeof(PeopleBase)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(p => p.FieldType == typeof(Person[]));

            Person[] people = new Person[] { new Person("Lola", 343434), new Person("John", 3434) };

            fieldValue.SetValue(db, people);

            FieldInfo currentIndexInfo = typeof(PeopleBase)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(p => p.FieldType == (typeof(int)));

            currentIndexInfo.SetValue(db, people.Length);


            Assert.That(db.FindByUsername("Lola").Id, Is.EqualTo(343434));
            Assert.That(db.FindByUsername("John").Id, Is.EqualTo(3434));
        }

        [Test]
        public void TestByUsernameInvalid()
        {
            PeopleBase db = new PeopleBase();

            FieldInfo fieldValue = typeof(PeopleBase)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(p => p.FieldType == typeof(Person[]));

            Person[] people = new Person[] { new Person("Lola", 343434), new Person("John", 3434) };

            fieldValue.SetValue(db, people);

            FieldInfo currentIndexInfo = typeof(PeopleBase)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(p => p.FieldType == (typeof(int)));

            currentIndexInfo.SetValue(db, people.Length);

            Assert.That(() => db.FindByUsername(null), Throws.ArgumentException);
            Assert.That(() => db.FindByUsername("Ken"), Throws.InvalidOperationException);
        }

        [Test]
        public void TestEmtpyDataBase()

        {
            PeopleBase db = new PeopleBase();

            Assert.That(() => db.FindByUsername("sds"), Throws.InvalidOperationException);
            Assert.That(() => db.FindById(12), Throws.InvalidOperationException);

        }


    }
}

