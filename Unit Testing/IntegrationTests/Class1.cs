using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using Integration;
using NUnit.Framework;

namespace IntegrationTests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        [TestCase("Lo")]
        public void TestUserConstructor(string name)
        {
           User user = new User(name);
            var nameInfo = typeof(User)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(p => p.FieldType == typeof(string));
            var str = (string) nameInfo.GetValue(user);
            Assert.That(str, Is.EqualTo(name));
        }

        [Test]
        [TestCase("Co")]
        public void TestUserConstructorCategory(string name)
        {
            Category cat = new Category(name);
            var nameInfo = typeof(Category)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(p => p.FieldType == typeof(string));
            var str = (string)nameInfo.GetValue(cat);
            Assert.That(str, Is.EqualTo(name));
        }

        [Test]
        [TestCase("K")]
        public void TestAddCategory(string name)
        {
            Category cat = new Category(name);
            Category child = new Category(name);
            cat.AddCategory(child);

            var catInfo = typeof(Category)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(p => p.FieldType == typeof(HashSet<Category>));
            var str = ((HashSet<Category>) catInfo.GetValue(cat));
            Category firstCat = str.FirstOrDefault();
            Assert.That(firstCat, Is.EqualTo(child));

        }

        [Test]
        [TestCase("K")]
        public void TestRemoveCategory(string name)
        {
            var cat1 = new Category(name);
            var cat2 = new Category(name);
            HashSet<User> users = new HashSet<User>{new User("A"), new User("B"), new User("c") };
            HashSet<Category> categories = new HashSet<Category> { new Category("A"), new Category("B")};

            var catInfo = typeof(Category)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(p => p.FieldType == typeof(HashSet<Category>));
            var userInfo = typeof(Category)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(p => p.FieldType == typeof(HashSet<User>));

            var relationShipInfo = typeof(Category)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(p => p.FieldType == typeof(Category));

            catInfo.SetValue(cat2, categories);

            userInfo.SetValue(cat2, users);

            catInfo.SetValue(cat1, new HashSet<Category>(){cat2});

            cat1.RemoveCategory();

            var cat1Child = (HashSet<Category>)catInfo.GetValue(cat1);
            var user1List = (HashSet<User>) userInfo.GetValue(cat1);
            
           var childCategory = (Category) relationShipInfo.GetValue(cat1Child.ElementAt(0));

            Assert.That(cat1Child, Is.EquivalentTo(categories));
            Assert.That(user1List, Is.EquivalentTo(users));
            Assert.That(childCategory, Is.EqualTo(cat1));
        }

        [Test]
        [TestCase("n")]
        public void TestAddUser(string name)
        {
            var cat = new Category(name);
            var user = new User(name);
            cat.AssignUser(user);

            var userInfo = typeof(Category)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(p => p.FieldType == typeof(HashSet<User>));

            var user1List = (HashSet<User>)userInfo.GetValue(cat);
            Assert.That(user1List.First(), Is.EqualTo(user));
            
        }

        [Test]
        [TestCase("n")]
        public void TestAddCategoryToUser(string name)
        {
            var cat = new Category(name);
            var user = new User(name);
            user.AddCategory(cat);
            var userInfo = typeof(User)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(p => p.FieldType == typeof(HashSet<Category>));
            var data = (HashSet<Category>) userInfo.GetValue(user);
            Assert.That(data.First, Is.EqualTo(cat));
        }


        [Test]
        [TestCase("n")]
        public void InvalidRemoveItem(string name)
        {
            var category = new Category(name);
            Assert.That(() => category.RemoveCategory(), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase("n")]
        public void TestRenmoceCategoryOfUser(string name)
        {
            var cat = new Category(name);
            var user = new User(name);
            var userInfo = typeof(User)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(p => p.FieldType == typeof(HashSet<Category>));
            userInfo.SetValue(user, new HashSet<Category>(){cat});

            user.RemoveCategory();

            var data = (HashSet<Category>)userInfo.GetValue(user);
            Assert.That(data.Count, Is.EqualTo(0));

        }

       




    }
}

